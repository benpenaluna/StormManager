using StormManager.UWP.Common;
using StormManager.UWP.Common.SqlTransactions;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;

namespace StormManager.UWP.Persistence.ObjectFramework
{
    public class RepoSet<TEntity> : ObservableCollectionEx<TEntity> where TEntity : class, INotifyPropertyChanged
    {
        internal string AddStoredProcedureName { get; set; }
        internal string UpdateStoredProcedureName { get; set; }
        internal string DeleteStoredProcedureName { get; set; }
        internal string GetAllStoredProcedureName { get; set; }


        internal RepoSet()
        {
            Initialise();
        }

        internal RepoSet(IEnumerable<TEntity> collection) : base(collection)
        {
            Initialise();
        }

        private void Initialise()
        {
            RepoChanges.Changes = new Queue<StateChange>();

            AttachEvents();
        }


        public void AttachEvents()
        {
            CollectionChanged += OnCollectionChanged;

            foreach (var item in Items)
            {
                item.PropertyChanged += ItemOnPropertyChanged;
            }
        }

        private void ItemOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (!RepoChanges.QueueContains(sender))
                RepoChanges.Changes.Enqueue(new StateChange(sender, SqlTransactionType.Update));
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Debugger.Break();
        }

        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            // TODO: Think about this. If item is added and then deleted, then the deletion should negate the addition and the
            // addition should be dequeued - we don't want to be sending two updates to the server unncessarily
            
            foreach (var addedItem in e.NewItems)
            {
                if (!(addedItem is TEntity entity) || RepoChanges.QueueContains(entity))
                    continue;

                RepoChanges.Changes.Enqueue(new StateChange(entity, SqlTransactionType.Insertion));
                entity.PropertyChanged += ItemOnPropertyChanged;
            }

            foreach (var deletedItem in e.OldItems)
            {
                if (!(deletedItem is TEntity entity) || RepoChanges.QueueContains(entity))
                    continue;

                RepoChanges.Changes.Enqueue(new StateChange(entity, SqlTransactionType.Deletion));
                entity.PropertyChanged += ItemOnPropertyChanged;
            }
        }
    }
}
