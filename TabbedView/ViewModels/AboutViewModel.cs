﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using TabbedView.Models;
using TabbedView.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace TabbedView.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public ICommand NewsFieldCommand { get; set; }
        List<NewsArticle> NewsData;
        public AboutViewModel()
        {
            NewsFieldCommand = new Command(NewsFieldOnClick);
            Title = "News";
            var startTimeSpan = TimeSpan.Zero;
            var periodTimeSpan = TimeSpan.FromMinutes(1);
            var timer = new System.Threading.Timer((e) =>
            {
                FetchDetails();
            }, null, startTimeSpan, periodTimeSpan);
        }

        private void NewsFieldOnClick(object obj)
        {
            var SelectedField = (NewsArticle)obj;
            if (SelectedField != null)
            {
                Launcher.OpenAsync(SelectedField.url);
            }
        }
        public async Task<List<NewsArticle>> FetchDetails()
        {
            SampleService toolsData = new SampleService();
            var SystemsData = await toolsData.FetchData();
            if (SystemsData != null || SystemsData.Count == 0)
            {
                NoData = false;
                IsLoader = false;
            }
            else
            {
                NoData = true;
                IsLoader = true;
            }
            NewsFields = SystemsData;
            return SystemsData;
        }

        bool _isLoader = false;
        public bool IsLoader
        {
            get => _isLoader;
            set
            {
                _isLoader = value;
                OnPropertyChanged("IsLoader");
            }
        }

        bool _noData = false;
        public bool NoData
        {
            get => _noData;
            set
            {
                _noData = value;
                OnPropertyChanged("NoData");
            }
        }

        List<NewsArticle> _myDeliveriesData;
        public List<NewsArticle> NewsFields
        {
            get { return _myDeliveriesData; }
            set
            {
                if (value != null)
                {
                    _myDeliveriesData = value;
                }
                OnPropertyChanged("NewsFields");
            }
        }
    }
}