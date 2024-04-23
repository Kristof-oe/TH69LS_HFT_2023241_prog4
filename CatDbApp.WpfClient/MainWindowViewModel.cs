using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TH69LS_HFT_2023241.Models;

namespace CatDbApp.WpfClient
{
    public class MainWindowViewModel:ObservableRecipient
    {
        public RestCollection<Cat> Cats { get; set; }
        public RestCollection<Cat_Owner> Cat_Owners { get; set; }

        public RestCollection<Cat_Sitter> Cat_Sitters { get; set; }

        private Cat selectedCat;

        public Cat SelectedCat
        {
            get { return selectedCat; }
            set {
                if (value != null)
                {
                    selectedCat = new Cat()
                    {
                        Cat_Name = value.Cat_Name,
                        CID = value.CID,
                    };
                    OnPropertyChanged();
                    (DeleteCatCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }

        }

        private Cat_Owner selectedCat_Owner;

        public Cat_Owner SelectedCat_Owner
        {
            get { return selectedCat_Owner; }
            set
            {
                if (value != null)
                {
                    selectedCat_Owner = new Cat_Owner()
                    {
                        Owner_Name = value.Owner_Name,
                        OID = value.OID
                    };
                    OnPropertyChanged();
                    (DeleteCat_OwnerCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }

        }
        private Cat_Sitter selectedCat_Sitter;

        public Cat_Sitter SelectedCat_Sitter
        {
            get { return selectedCat_Sitter; }
            set
            {
                if (value != null)
                {
                    selectedCat_Sitter = new Cat_Sitter()
                    {
                        Sitter_Name = value.Sitter_Name,
                        SID = value.SID

                    };
                    OnPropertyChanged();
                    (DeleteCat_SitterCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }

        }



        //Cat
        public ICommand CreateCatCommand { get; set; }

        public ICommand DeleteCatCommand { get; set; }

        public ICommand UpdateCatCommand { get; set; }
        //Cat_Owner
        public ICommand CreateCat_OwnerCommand { get; set; }

        public ICommand DeleteCat_OwnerCommand { get; set; }

        public ICommand UpdateCat_OwnerCommand { get; set; }
        //Cat_Sitter
        public ICommand CreateCat_SitterCommand { get; set; }

        public ICommand DeleteCat_SitterCommand { get; set; }

        public ICommand UpdateCat_SitterCommand { get; set; }


        public static bool IsInDesgignMode
        {
            get
            {
                var prop=DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }



        public MainWindowViewModel()
        {

            if (!IsInDesgignMode)
            { 
                Cats = new RestCollection<Cat>("http://localhost:32149/", "Cat", "hub");

                Cat_Owners = new RestCollection<Cat_Owner>("http://localhost:32149/", "Cat_Owner", "hub");

                Cat_Sitters = new RestCollection<Cat_Sitter>("http://localhost:32149/", "Cat_Sitter", "hub");
                //Cat
                CreateCatCommand = new RelayCommand(() =>
                 Cats.Add(new Cat()
                {
                    Cat_Name = SelectedCat.Cat_Name
                }));

                 DeleteCatCommand = new RelayCommand(
                     () =>
                  Cats.Delete(SelectedCat.CID),
                     ()=>{return SelectedCat != null;
                     });

                UpdateCatCommand = new RelayCommand(() =>
                Cats.Update(SelectedCat)
                );

                //Owner
                CreateCat_OwnerCommand = new RelayCommand(() =>
                 Cat_Owners.Add(new Cat_Owner()
                {
                    Owner_Name = SelectedCat_Owner.Owner_Name

                }));

                DeleteCat_OwnerCommand = new RelayCommand(
                    () =>
                Cat_Owners.Delete(SelectedCat_Owner.OID),
                () => { return SelectedCat_Owner != null;
                });

                UpdateCat_OwnerCommand = new RelayCommand(() => 
                Cat_Owners.Update(SelectedCat_Owner)
                );

                //Sitter
                CreateCat_SitterCommand = new RelayCommand(() =>
                Cat_Sitters.Add(new Cat_Sitter()
                {
                    Sitter_Name = SelectedCat_Sitter.Sitter_Name,
                    CID = SelectedCat.CID

                })) ;

                DeleteCat_SitterCommand = new RelayCommand(() =>
                Cat_Sitters.Delete(SelectedCat_Sitter.SID), 
                () => { return SelectedCat_Sitter != null; 
                });

                UpdateCat_SitterCommand = new RelayCommand(() => 
                Cat_Sitters.Update(SelectedCat_Sitter)
                );

                SelectedCat = new Cat();
                SelectedCat_Owner = new Cat_Owner();
                SelectedCat_Sitter= new Cat_Sitter();
            }
        }
            
    }
}
