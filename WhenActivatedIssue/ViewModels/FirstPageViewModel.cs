using System;
using System.Reactive.Linq;
using ReactiveUI;
using System.Reactive.Disposables;
namespace WhenActivatedIssue.ViewModels
{
    public class FirstPageViewModel : ReactiveObject, ISupportsActivation
    {
		private string _labelText;
        public string LabelText
		{
			get { return _labelText; }
			set { this.RaiseAndSetIfChanged(ref _labelText, value); }
		}
		private readonly ViewModelActivator _viewModelActivator = new ViewModelActivator();
		ViewModelActivator ISupportsActivation.Activator
		{
			get { return _viewModelActivator; }
		}
        public FirstPageViewModel()
        {
            this.WhenActivated(disposables =>
            {
                this.GetString().Subscribe(x => this.LabelText = x).DisposeWith(disposables);
            });
        }
        public IObservable<string> GetString()
        {
            return Observable.Return<string>("Welcome to Xamarin Forms !!");
        }
    }
}
