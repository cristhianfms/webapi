using System;
using System.Collections.Generic;
using Reports.BusinessLogic.Interface;
using Reports.Domain;
using Reports.DataAccess.Interface;
using System.Linq;

namespace Reports.BusinessLogic
{
    public class UserLogic : IUserLogic
    {
        private IRepository<User> userRepo;
        private IRepository<IndicatorConfig> indicatorConfigRepo;
        private IRepository<Indicator> indicatorRepo;

        public UserLogic(IRepository<User> userRepo, IRepository<IndicatorConfig> indConfRepo,
            IRepository<Indicator> indicatorRepo)
        {
            this.userRepo = userRepo;
            this.indicatorConfigRepo = indConfRepo;
            this.indicatorRepo = indicatorRepo;
        }
        public User Create(User usr) {
            try
            {
                CheckEmtpyUser(usr);
                usr.Id = Guid.NewGuid();
                CheckIfUserIsOK(usr);
                userRepo.Add(usr);
                userRepo.Save();
                return usr;
            }
            catch (RepositoryInterfaceException e)
            {
                throw new BusinessLogicException(e.Message, e);
            }
        }
        public User Get(Guid id)
        {
            try
            {
                return this.userRepo.Get(id);
            }
            catch (RepositoryInterfaceException e)
            {
                throw new BusinessLogicException(e.Message, e);
            }

        }
        public IEnumerable<User> GetAll()
        {
            try
            {
                return this.userRepo.GetAll();
            }
            catch (RepositoryInterfaceException e)
            {
                throw new BusinessLogicException(e.Message, e);
            }
        }
        public void Remove(User usr)
        {
            try
            {
                CheckEmtpyUser(usr);
                CheckIfUserIsOK(usr);
                this.userRepo.Remove(usr);
                this.userRepo.Save();
            }
            catch(RepositoryInterfaceException e)
            {
                throw new BusinessLogicException(e.Message, e);
            }
        }
        public User Update(User usr)
        {
            try
            {
                CheckEmtpyUser(usr);
                CheckIfUserIsOK(usr);
                this.userRepo.Update(usr);
                this.userRepo.Save();
                return usr;
            }
            catch (RepositoryInterfaceException e)
            {
                throw new BusinessLogicException(e.Message, e);
            }
        }
        public IEnumerable<IndicatorConfig> GetIndicatorConfigs(Guid userId, Guid areaId)
        {
            List<IndicatorConfig> indConfigs = indicatorConfigRepo.GetAll()
                .Where(ic => ic.UserId == userId && ic.Indicator.AreaId == areaId).ToList();
            return indConfigs;
        }
        public IndicatorConfig GetIndicatorConfig(Guid userId, Guid indicatorId)
        {
            IndicatorConfig indConfig = indicatorConfigRepo.GetAll()
                .FirstOrDefault(ic => ic.UserId == userId && ic.IndicatorId == indicatorId);

            if (indConfig != null)
            {
                return indConfig;
            }
            else
            {
                throw new BusinessLogicInterfaceException("IndicatorConfig not found");
            }
        }
        public void SetIndicatorPosition(Guid userId, Guid indicatorId, int pos)
        {
            IndicatorConfig indConfig = indicatorConfigRepo.GetAll()
                .FirstOrDefault(ic => ic.UserId == userId && ic.IndicatorId == indicatorId);

            if(indConfig == null)
            {
                AddNewIndicatorConfig(userId, indicatorId, pos);
            }
            else
            {
                indConfig.Position = pos;
                indicatorConfigRepo.Update(indConfig);
                indicatorConfigRepo.Save();
            }
        }
        public void SetIndicatorVisible(Guid userId, Guid indicatorId, bool visible)
        {
            IndicatorConfig indConfig = indicatorConfigRepo.GetAll()
                .FirstOrDefault(ic => ic.UserId == userId && ic.IndicatorId == indicatorId);

            if (indConfig == null)
            {
                AddNewIndicatorConfig(userId, indicatorId, visible);
            }
            else
            {
                indConfig.Visible = visible;
                indicatorConfigRepo.Update(indConfig);
                indicatorConfigRepo.Save();
            }
        }
        public void SetIndicatorCustomName(Guid userId, Guid indicatorId, string customName)
        {
            IndicatorConfig indConfig = indicatorConfigRepo.GetAll()
                .FirstOrDefault(ic => ic.UserId == userId && ic.IndicatorId == indicatorId);

            if (indConfig == null)
            {
                AddNewIndicatorConfig(userId, indicatorId, customName);
            }
            else
            {
                indConfig.CustomName = customName;
                indicatorConfigRepo.Update(indConfig);
                indicatorConfigRepo.Save();
            }
        }
        public IEnumerable<Area> GetManagedAreas(Guid userId)
        {
            User user = userRepo.Get(userId);
            CheckIfUserManagerRol(user);
            List<Area> areas = user.AreaUsers.Select(au => au.Area).ToList();
            return areas;
        }

        private void CheckIfUserIsOK(User usr)
        {
            if (!usr.IsValid())
            {
                throw new BusinessLogicException("User instance is not correct");
            }
        }
        private void CheckEmtpyUser(User usr)
        {
            if (usr == null)
            {
                throw new BusinessLogicException("Null user instance");
            }
        }
        private void AddNewIndicatorConfig(Guid userId, Guid indicatorId, int pos)
        {
            try
            {
                User user = userRepo.Get(userId);
                Indicator indicator = indicatorRepo.Get(indicatorId);
                CheckIfUserManagerRol(user);
                IndicatorConfig indicatorConfig = new IndicatorConfig()
                {
                    Id = Guid.NewGuid(),
                    Indicator = indicator,
                    User = user,
                    Position = pos,
                    CustomName = indicator.Name,
                };
                indicatorConfigRepo.Add(indicatorConfig);
                indicatorConfigRepo.Save();
            }
            catch (RepositoryInterfaceException e)
            {
                throw new BusinessLogicException("Rpository error", e);
            }
        }
        private void CheckIfUserManagerRol(User user)
        {
            if (user.Admin == true)
            {
                throw new BusinessLogicException("User must have a manager rol");
            }
        }
        private void AddNewIndicatorConfig(Guid userId, Guid indicatorId, bool visible)
        {
            try
            {
                User user = userRepo.Get(userId);
                Indicator indicator = indicatorRepo.Get(indicatorId);
                CheckIfUserManagerRol(user);
                IndicatorConfig indicatorConfig = new IndicatorConfig()
                {
                    Id = Guid.NewGuid(),
                    Indicator = indicator,
                    User = user,
                    Visible = visible,
                    CustomName = indicator.Name,
                };
                indicatorConfigRepo.Add(indicatorConfig);
                indicatorConfigRepo.Save();
            }
            catch (RepositoryInterfaceException e)
            {
                throw new BusinessLogicException("Rpository error", e);
            }
        }
        private void AddNewIndicatorConfig(Guid userId, Guid indicatorId, string customName)
        {
            try
            {
                User user = userRepo.Get(userId);
                Indicator indicator = indicatorRepo.Get(indicatorId);
                CheckIfUserManagerRol(user);
                IndicatorConfig indicatorConfig = new IndicatorConfig()
                {
                    Id = Guid.NewGuid(),
                    Indicator = indicator,
                    User = user,
                    CustomName = customName,
                };
                indicatorConfigRepo.Add(indicatorConfig);
                indicatorConfigRepo.Save();
            }
            catch (RepositoryInterfaceException e)
            {
                throw new BusinessLogicException("Rpository error", e);
            }
        }
    }
}
