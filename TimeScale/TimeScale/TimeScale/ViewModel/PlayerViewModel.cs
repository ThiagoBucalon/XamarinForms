﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using TimeScale.Model;

namespace TimeScale.ViewModel
{
    public class PlayerViewModel : BaseViewModel
    {
        private List<string> _position = new List<string>();
        private string myname;

        public string MyName
        {
            get
            {
                return myname;
            }
            set
            {
                if (myname != value)
                {
                    myname = value;
                    OnPropertyChanged("MyName");
                }
            }
        }
        
        public List<string> Position
        {
            get
            {
                return _position;
            }
            set
            {
                if (SetProperty(ref _position, value))
                    PositionCommand.ChangeCanExecute();
            }
        }

      
        public Command PositionCommand
        {
            get;
        }

           
        public Command GoleiroCommand
        {
            get;
        }

        public Command LateralEsqCommand
        {
            get;
        }

        public Command ZagueiroCommand
        {
            get;
        }

        public Command LateralDirCommand
        {
            get;
        }

        public Command VolanteCommand
        {
            get;
        }

        public Command MeioCommand
        {
            get;
        }

        public Command AtaqueCommand
        {
            get;
        }

        public Command SaveCommand
        {
            get;
        }

        public PlayerViewModel()
        {            
            PositionCommand = new Command(ExecutePositionCommand);
            GoleiroCommand = new Command(ExecuteGoleiroCommand);
            LateralEsqCommand = new Command(ExecuteLateralEsqCommand);
            ZagueiroCommand = new Command(ExecuteZagueiroCommand);
            LateralDirCommand = new Command(ExecuteLateralDirCommand);
            VolanteCommand = new Command(ExecuteVolanteCommand);
            MeioCommand = new Command(ExecuteMeioCommand);
            AtaqueCommand = new Command(ExecuteAtaqueCommand);
            SaveCommand = new Command(ExecuteSaveCommand);
        }

        async void ExecutePositionCommand()
        {
           // _position.Add("goleiro");
        }

        async void ExecuteGoleiroCommand()
        {
            _position.Add("GOL");
        }

        async void ExecuteLateralEsqCommand()
        {
            _position.Add("LE");
        }

        async void ExecuteZagueiroCommand()
        {
            _position.Add("ZAG");
        }

        async void ExecuteLateralDirCommand()
        {
            _position.Add("LD");
        }

        async void ExecuteVolanteCommand()
        {
            _position.Add("VOL");
        }

        async void ExecuteMeioCommand()
        {
            _position.Add("MC");
        }

        async void ExecuteAtaqueCommand()
        {
            _position.Add("ATA");
        }

        async void ExecuteSaveCommand()
        {
            string p = "GOL";
            myname = "Bucalon";
            var player = new Player
            {
                Name = myname.ToString(),
                Position = p,
                Offensive = 5,
                Defensive = 7,
            };

            using (var data = new AcessDB())
            {
                data.InsertPlayer(player);
            }
            
            // save no BD antes
           // _position.Clear();
          //  MainViewModel._numberPlayer++;
            await PopAsync<PlayerViewModel>();
        }


    }
}
