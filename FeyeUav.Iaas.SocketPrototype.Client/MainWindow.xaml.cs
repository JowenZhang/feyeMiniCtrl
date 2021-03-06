﻿using FeyeUav.Iaas.SocketPrototype.Client.Bll;
using FeyeUav.Iaas.SocketPrototype.Client.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Media;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FeyeUav.Iaas.SocketPrototype.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            IsSend = false;
            if (_timer==null)
            {
               _timer=new System.Threading.Timer(new TimerCallback(RefreshLayout), null, 0, 1000);
            }
            InitializeComponent();
            ServerDataSetting(false);
        }

        /// <summary>
        /// data setting
        /// </summary>
        /// <param name="isSend">is send</param>
        private void ServerDataSetting(bool isSend)
        {
            IsSend = isSend;
            if (_timer!=null)
            {
                if (IsSend)
                {
                    _timer.Change(Timeout.Infinite, 1000);
                }
                else
                {
                    _timer.Change(0, 1000);
                }
            }
        }

        private System.Threading.Timer _timer = null;


        private ctl_fly _last = null;

        private void RefreshLayout(object state)
        {
            lock (this)
            {
                CtlFlyBll bll = new CtlFlyBll();
                string msg = string.Empty;
                _last = bll.ReadAndAnalysis(_last, out msg);
                //if (_last!=null)
                //{
                //    PrintMsg(_last.fly_code.ToString() + _last.input_time);
                //}
                if (!string.IsNullOrWhiteSpace(msg))
                {
                    SystemSounds.Beep.Play();
                    PrintMsg(msg);
                    if (_last != null)
                    {
                        switch (_last.fly_code)
                        {
                            case 1:
                                ChangeForeColor(txtOn, Color.FromRgb(255,52,0));
                                Thread.Sleep(3000);
                                ChangeForeColor(txtOn, Color.FromRgb(135, 206, 235));
                                break;
                            case 2:
                                ChangeForeColor(txtOff, Color.FromRgb(255, 52, 0));
                                Thread.Sleep(3000);
                                ChangeForeColor(txtOff, Color.FromRgb(116, 116, 222));
                                break;
                            case 3:
                                ChangeForeColor(txtUp, Color.FromRgb(255, 52, 0));
                                Thread.Sleep(3000);
                                ChangeForeColor(txtUp, Color.FromRgb(0, 128, 0));
                                break;
                            case 4:
                                ChangeForeColor(txtDown, Color.FromRgb(255, 52, 0));
                                Thread.Sleep(3000);
                                ChangeForeColor(txtDown, Color.FromRgb(0, 128, 0));
                                break;
                            case 5:
                                ChangeForeColor(txtLeft, Color.FromRgb(255, 52, 0));
                                Thread.Sleep(3000);
                                ChangeForeColor(txtLeft, Color.FromRgb(0, 128, 0));
                                break;
                            case 6:
                                ChangeForeColor(txtRight, Color.FromRgb(255, 52, 0));
                                Thread.Sleep(3000);
                                ChangeForeColor(txtRight, Color.FromRgb(0, 128, 0));
                                break;
                            default:
                                break;
                        }
                    }
                }
            }           
            
        }

        private void RemoteSetting(object sender, ExecutedRoutedEventArgs e)
        {
            SettingWindow sw = new SettingWindow();
            sw.Setting += ServerDataSetting;
            sw.Show();
        }

        /// <summary>
        /// print message
        /// </summary>
        /// <param name="msg">the message need to print</param>
        /// <param name="cleanBeforePrint">clean message before print</param>
        private void PrintMsg(string msg, bool cleanBeforePrint = false)
        {
            txtShow.Dispatcher.Invoke(() => {
                if (cleanBeforePrint)
                {
                    txtShow.Text = string.Empty;
                }
                if (string.IsNullOrWhiteSpace(txtShow.Text))
                {
                    txtShow.Text += msg;
                }
                else
                {
                    txtShow.Text += "\r\n" + msg;
                }
            });
        }

        private void ChangeForeColor(TextBlock txtBlock, Color col)
        {
            txtBlock.Dispatcher.Invoke(() => {
                txtBlock.Foreground = new SolidColorBrush(col);                
            });
        }

        private bool IsSend { get; set; }


        private void FlyOnEnter(object sender, MouseEventArgs e)
        {
            if (IsSend)
            {
                TextBlock txtBlock = sender as TextBlock;
                if (txtBlock == null)
                {
                    return;
                }
                txtBlock.Foreground = new SolidColorBrush(Color.FromRgb(0, 183, 255));
            }
        }

        private void FlyOnLeave(object sender, MouseEventArgs e)
        {
            if (IsSend)
            {
                TextBlock txtBlock = sender as TextBlock;
                if (txtBlock == null)
                {
                    return;
                }
                txtBlock.Foreground = new SolidColorBrush(Color.FromRgb(135, 206, 235));
            }
        }

        private void FlyOffEnter(object sender, MouseEventArgs e)
        {
            if (IsSend)
            {
                TextBlock txtBlock = sender as TextBlock;
                if (txtBlock == null)
                {
                    return;
                }
                txtBlock.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 255));
            }
        }

        private void FlyOffLeave(object sender, MouseEventArgs e)
        {
            if (IsSend)
            {
                TextBlock txtBlock = sender as TextBlock;
                if (txtBlock == null)
                {
                    return;
                }
                txtBlock.Foreground = new SolidColorBrush(Color.FromRgb(116, 116, 222));
            }
        }

        private void FlyBtnEnter(object sender, MouseEventArgs e)
        {
            if (IsSend)
            {
                TextBlock txtBlock = sender as TextBlock;
                if (txtBlock == null)
                {
                    return;
                }
                txtBlock.Foreground = new SolidColorBrush(Color.FromRgb(44, 180, 44));
            }
        }

        private void FlyBtnLeave(object sender, MouseEventArgs e)
        {
            if (IsSend)
            {
                TextBlock txtBlock = sender as TextBlock;
                if (txtBlock == null)
                {
                    return;
                }
                txtBlock.Foreground = new SolidColorBrush(Color.FromRgb(0, 128, 0));
            }
        }

        private void FlyDownDown(object sender, MouseButtonEventArgs e)
        {
            if (IsSend)
            {
                PrintMsg($@"{DateTime.Now.ToString("yyyyMMdd HH:mm:ss")}下达下降指令");
                CtlFlyBll bll = new CtlFlyBll();
                bll.FlyDown();
            }
            
        }

        private void FlyRightDown(object sender, MouseButtonEventArgs e)
        {
            if (IsSend)
            {
                PrintMsg($@"{DateTime.Now.ToString("yyyyMMdd HH:mm:ss")}下达右转指令");
                CtlFlyBll bll = new CtlFlyBll();
                bll.FlyRight();
            }
            
        }

        private void FlyLeftDown(object sender, MouseButtonEventArgs e)
        {
            if (IsSend)
            {
                PrintMsg($@"{DateTime.Now.ToString("yyyyMMdd HH:mm:ss")}下达左转指令");
                CtlFlyBll bll = new CtlFlyBll();
                bll.FlyLeft();
            }
            
        }

        private void FlyUpDown(object sender, MouseButtonEventArgs e)
        {
            if (IsSend)
            {
                PrintMsg($@"{DateTime.Now.ToString("yyyyMMdd HH:mm:ss")}下达上升指令");
                CtlFlyBll bll = new CtlFlyBll();
                bll.FlyUp();
            }
            
        }

        private void FlyOnDown(object sender, MouseButtonEventArgs e)
        {
            if (IsSend)
            {
                PrintMsg($@"{DateTime.Now.ToString("yyyyMMdd HH:mm:ss")}下达起飞指令");
                CtlFlyBll bll = new CtlFlyBll();
                bll.FlyOn();
            }
            
        }

        private void FlyOffDown(object sender, MouseButtonEventArgs e)
        {
            if (IsSend)
            {
                PrintMsg($@"{DateTime.Now.ToString("yyyyMMdd HH:mm:ss")}下达降落指令");
                CtlFlyBll bll = new CtlFlyBll();
                bll.FlyOff();
            }
            
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            _timer.Change(Timeout.Infinite, 1000);
            _timer.Dispose();
        }
    }
}
