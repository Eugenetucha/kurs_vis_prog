using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using ReactiveUI;
using System.Reactive.Linq;
using Vis_curs.Models;

namespace Vis_curs.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            CreateTabs();
            CreateGrid();
            CreateRequests();
            Content = Fv = new FirstViewModel(this);
            Sv = new SecondViewModel(this);
        }

        public FirstViewModel Fv { get; }
        public SecondViewModel Sv { get; }

        public void Change()
        {
            if (Content == Fv)
                Content = Sv;
            else if (Content == Sv)
                Content = Fv;
        }

        ViewModelBase content;
        public ViewModelBase Content
        {
            get { return content; }
            set { this.RaiseAndSetIfChanged(ref content, value); }
        }

        ObservableCollection<Tabs> tab;
        public ObservableCollection<Tabs> Tab
        {
            get { return tab; }
            set { this.RaiseAndSetIfChanged(ref tab, value); }
        }
        private void CreateTabs()
        {
            Tab = new ObservableCollection<Tabs>();
            Tab.Add(new Tabs("Players",false));
            Tab.Add(new Tabs("Teams", false));
            Tab.Add(new Tabs("Players results", false));
            Tab.Add(new Tabs("Race", false));
            Tab.Add(new Tabs("Tracks", false));
            Tab.Add(new Tabs("request 1", true));
            Tab.Add(new Tabs("request 2", true));
            Tab.Add(new Tabs("request 3", true));

        }

        ObservableCollection<Tabs> request;
        public ObservableCollection<Tabs> Request
        {
            get { return request; }
            set { this.RaiseAndSetIfChanged(ref request, value); }
        }

        private void CreateRequests()
        {
            Request = new ObservableCollection<Tabs>();
            Request.Add(new Tabs("request 1", true));
            Request.Add(new Tabs("request 2", true));
            Request.Add(new Tabs("request 3", true));
        }

        ObservableCollection<Grids> grid;
        public ObservableCollection<Grids> Grid
        {
            get { return grid; }
            set { this.RaiseAndSetIfChanged(ref grid, value); }
        }
        private void CreateGrid()
        {
            Grid = new ObservableCollection<Grids>();
            Grid.Add(new Grids("Valentino Rossi", "10.10.2002", "Greece" , "12", "10", "11"));
            Grid.Add(new Grids("Joe Thornton", "06.07.1986", "USA", "10", "9", "10"));
            Grid.Add(new Grids("Evgeni Tuchkin", "03.05.2000", "Russia", "3", "3", "3"));
        }



        


    }
}
