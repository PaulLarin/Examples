    /// <summary>
    /// Базовая ViewModel для <see cref="GridWithToolbox"/>
    /// </summary>
    /// <typeparam name="TItemViewModel">ViewModel элементов списка</typeparam>
    public abstract class GridWithToolboxViewModelBase<TItemViewModel> : ViewModelBase, IGridWithToolboxViewModelBase<TItemViewModel>
        where TItemViewModel : class
    {
        private ICommand _addNewCommand;
        private ICommand _editCommand;
        private ICommand _removeCommand;

        protected abstract void EditItemAction();
        protected abstract void AddNewItemAction();
        protected abstract void RemoveItemAction();


        public ICommand AddNewCommand => _addNewCommand ?? (_addNewCommand = new SafeCommand(AddNewItemAction));

        public ICommand EditCommand => _editCommand ?? (_editCommand = new SafeCommand(EditItemAction, () => SelectedItem != null));

        public ICommand RemoveCommand => _removeCommand ?? (_removeCommand = new SafeCommand(RemoveItemAction, () => SelectedItem != null));


        public ObservableCollection<TItemViewModel> Items { get; } = new ObservableCollection<TItemViewModel>();

        public bool IsBusy
        {
            get { return GetProperty(() => IsBusy); }
            protected set { SetProperty(() => IsBusy, value); }
        }

        public TItemViewModel SelectedItem
        {
            get { return GetProperty(() => SelectedItem); }
            set { SetProperty(() => SelectedItem, value); }
        }

        public abstract void Refresh();
        public bool IsReadonly { get; protected set; }
    }