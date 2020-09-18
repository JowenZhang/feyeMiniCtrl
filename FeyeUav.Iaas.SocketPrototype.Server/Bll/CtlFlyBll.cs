using FeyeUav.Iaas.SocketPrototype.Server.Dal;
using FeyeUav.Iaas.SocketPrototype.Server.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FeyeUav.Iaas.SocketPrototype.Client.Bll
{
    public class CtlFlyBll
    {
        public bool FlyOn()
        {
            ctl_fly ctlFly = new ctl_fly() { id = 1, input_time = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")), fly_code = 1 };
            try
            {
                return Update(ctlFly);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool FlyOff()
        {
            ctl_fly ctlFly = new ctl_fly() { id = 1, input_time = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")), fly_code = 2 };
            try
            {
                return Update(ctlFly);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool FlyUp()
        {
            ctl_fly ctlFly = new ctl_fly() { id = 1, input_time = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")), fly_code = 3 };
            try
            {
                return Update(ctlFly);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool FlyDown()
        {
            ctl_fly ctlFly = new ctl_fly() { id = 1, input_time = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")), fly_code = 4 };
            try
            {
                return Update(ctlFly);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool FlyLeft()
        {
            ctl_fly ctlFly = new ctl_fly() { id = 1, input_time = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")), fly_code = 5 };
            try
            {
                return Update(ctlFly);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool FlyRight()
        {
            ctl_fly ctlFly = new ctl_fly() { id = 1, input_time = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")), fly_code = 6 };
            try
            {
                return Update(ctlFly);
            }
            catch (Exception)
            {

                throw;
            }
        }


        private bool Update(ctl_fly ctlFly)
        {
            if (ctlFly == null || ctlFly.id != 1)
            {
                throw new Exception("couldnot be null and id must be 1");
            }
            try
            {
                CtlFlyDal dal = new CtlFlyDal();
                if (dal.GetCount() > 0)
                {
                    return dal.Update(ctlFly) > 0;
                }
                else
                {
                    return dal.Insert(ctlFly) > 0;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public ctl_fly ReadAndAnalysis(ctl_fly lastCommand, out string msg)
        {
            try
            {
                CtlFlyDal dal = new CtlFlyDal();
                ctl_fly newCommand = dal.GetSingle();
                if (lastCommand == null && newCommand == null)
                {
                    msg = null;
                    return null;
                }
                else if (lastCommand == null && newCommand != null)
                {
                    msg = CommandToString(newCommand);
                    return newCommand;
                }
                else if (lastCommand != null && newCommand == null)
                {
                    msg = "命令已初始化完成";
                    return null;
                }
                else
                {
                    if (lastCommand.input_time == newCommand.input_time && lastCommand.fly_code == newCommand.fly_code)
                    {
                        msg = null;
                        return newCommand;
                    }
                    else
                    {
                        msg = CommandToString(newCommand);
                        return newCommand;
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private string CommandToString(ctl_fly newCommand)
        {
            if (newCommand == null)
            {
                return null;
            }
            switch (newCommand.fly_code)
            {
                case 1:
                    return $@"{newCommand.input_time.ToString("yyyyMMdd HH:mm:ss")}执行起飞指令";
                case 2:
                    return $@"{newCommand.input_time.ToString("yyyyMMdd HH:mm:ss")}执行降落指令";
                case 3:
                    return $@"{newCommand.input_time.ToString("yyyyMMdd HH:mm:ss")}执行上升指令";
                case 4:
                    return $@"{newCommand.input_time.ToString("yyyyMMdd HH:mm:ss")}执行下降指令";
                case 5:
                    return $@"{newCommand.input_time.ToString("yyyyMMdd HH:mm:ss")}执行左转指令";
                case 6:
                    return $@"{newCommand.input_time.ToString("yyyyMMdd HH:mm:ss")}执行右转指令";
                default:
                    return null;
            }
        }
    }
}
