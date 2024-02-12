using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behpouyan
{
    internal class TankViewModel : INotifyPropertyChanged
    {
        private TankContext _context;
        private Tank _tank;


        public int Value
        {
            get
            {
                return _tank.Value;
            }
            set
            {
                 _tank.Value = value;
                OnPropertyChange(nameof(Value));
                UpdateColor();

            }
        }

        public string Color
        {
            get { return _tank.Color; }
            set
            {
                _tank.Color = value;
                OnPropertyChange(nameof(Color));
                UpdateColor();
            }
        }

        private void UpdateColor()
        {
            if(Value > 200)
            {
                Color = "Red";
            }
            else if(Value > 150)
            {
                Color = "Blue";
            }
            else
            {
                Color = "Green";
            }
        }


        public TankViewModel()
        {
            _context = new TankContext("Tank");
            _tank = _context.tanks.Find(3);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChange(string prop)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
}
