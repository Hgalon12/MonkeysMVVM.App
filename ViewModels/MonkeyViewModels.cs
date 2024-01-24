using MonkeysMVVM.Models;
using MonkeysMVVM.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonkeysMVVM.ViewModels
{
    internal class MonkeyViewModels:ViewModelBase
    {
        private string name;
        public string Name
        {
            get { return this.name; }
            set
            {
                this.name = value;
                OnPropertyChanged();
            }
        }
        private string location;
        public string Location
        {
            get { return this.location; }
            set
            {
                this.location = value;
                OnPropertyChanged();
            }
        }

        private string imageUrl;
        public string ImageUrl
        {
            get { return this.imageUrl; }
            set
            {
                this.imageUrl = value;
                OnPropertyChanged();
            }
        }

        public Command GetMonkeyCommand { get; set; }
         
        private string locationEntry;
        public string LocationEntry
        {
            get { return this.locationEntry; }

        }
        private int allMonkeys;
        public int AllMonkeys
        {
            get { return this.allMonkeys; }
            set
            {
                this.allMonkeys = value;
                OnPropertyChanged();
            }
        }
        public MonkeyViewModels()
        {
            GetMonkeyCommand = new Command(GetMonkey);

        }
        private async void GetMonkey()
        {
            MonkeysService service = new MonkeysService();
            List<Monkey> monkeys = await service.GetMonkeysByLocation(this.locationEntry);
            AllMonkeys = monkeys.Count;
           if(monkeys.Count> 0)
            {
               Name = monkeys[0].Name;
               Location = monkeys[0].Location;
               imageUrl = monkeys[0].ImageUrl;
            }
            else
            {
                Name = "Not found";
                ImageUrl = "";
            }


        }

    }
}
