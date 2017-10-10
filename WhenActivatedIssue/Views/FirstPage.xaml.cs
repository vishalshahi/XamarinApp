using System;
using System.Collections.Generic;
using ReactiveUI;
using Xamarin.Forms;
using WhenActivatedIssue.ViewModels;

namespace WhenActivatedIssue.Views
{
    public partial class FirstPage : ContentPage,IViewFor<FirstPageViewModel>
    {
        public FirstPage()
        {
            InitializeComponent();
            ViewModel = new FirstPageViewModel();
			this.WhenActivated(disposables =>
			{
				this.Bind(ViewModel, vm => vm.LabelText, v => v.label.Text);
			});
		}
        public static readonly BindableProperty ViewModelProperty = BindableProperty.Create(nameof(ViewModel), typeof(FirstPageViewModel), typeof(FirstPage), null, BindingMode.OneWay);
		public FirstPageViewModel ViewModel
		{
			get { return (FirstPageViewModel)GetValue(ViewModelProperty); }
			set
			{
				if (ViewModel == null)
					SetValue(ViewModelProperty, value);
			}
		}
		object IViewFor.ViewModel
		{
			get { return ViewModel; }
			set { ViewModel = (FirstPageViewModel)value; }
		}
    }
}
