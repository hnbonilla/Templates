﻿
//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a CodeSmith Template.
//
//     DO NOT MODIFY contents of this file. Changes to this
//     file will be lost if the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;

namespace Tester.Data
{
    /// <summary>
    /// The manager class for Junction.
    /// </summary>
    public partial class JunctionManager 
        : CodeSmith.Data.EntityManagerBase<TesterDataManager, Tester.Data.Junction>
    {
        /// <summary>
        /// Initializes the <see cref="JunctionManager"/> class.
        /// </summary>
        static JunctionManager()
        {
            AddRules();
        }

        /// <summary>
        /// Initializes the <see cref="JunctionManager"/> class.
        /// </summary>
        /// <param name="manager">The current manager.</param>
        public JunctionManager(TesterDataManager manager) : base(manager)
        {
            OnCreated();
        }

        /// <summary>
        /// Gets the current context.
        /// </summary>
        protected Tester.Data.TesterDataContext Context
        {
            get { return Manager.Context; }
        }
        
        /// <summary>
        /// Gets the entity for this manager.
        /// </summary>
        protected System.Data.Linq.Table<Tester.Data.Junction> Entity
        {
            get { return Manager.Context.Junction; }
        }
        
        
        /// <summary>
        /// Creates the key for this entity.
        /// </summary>
        public static CodeSmith.Data.IEntityKey<int, int> CreateKey(int leftId, int rightId)
        {
            return new CodeSmith.Data.EntityKey<int, int>(leftId, rightId);
        }
        
        /// <summary>
        /// Gets an entity by the primary key.
        /// </summary>
        /// <param name="key">The key for the entity.</param>
        /// <returns>
        /// An instance of the entity or null if not found.
        /// </returns>
        /// <remarks>
        /// This method is expecting key to be of type IEntityKey&lt;int, int&gt;.
        /// </remarks>
        /// <exception cref="ArgumentException">Thrown when key is not of type IEntityKey&lt;int, int&gt;.</exception>
        public override Tester.Data.Junction GetByKey(CodeSmith.Data.IEntityKey key)
        {
            if (key is CodeSmith.Data.IEntityKey<int, int>)
            {
                var entityKey = (CodeSmith.Data.IEntityKey<int, int>)key;
                return GetByKey(entityKey.Key, entityKey.Key1);
            }
            else
            {
                throw new ArgumentException("Invalid key, expected key to be of type IEntityKey<int, int>");
            }
        }
        
        /// <summary>
        /// Gets an instance by the primary key.
        /// </summary>
        /// <returns>An instance of the entity or null if not found.</returns>
        public Tester.Data.Junction GetByKey(int leftId, int rightId)
        {
            if (Context.LoadOptions == null) 
                return Query.GetByKey.Invoke(Context, leftId, rightId);
            else
                return Entity.FirstOrDefault(j => j.LeftId == leftId 
					&& j.RightId == rightId);
        }
        
        /// <summary>
        /// Immediately deletes the entity by the primary key from the underlying data source with a single delete command.
        /// </summary>
        /// <returns>The number of rows deleted from the database.</returns>
        public int Delete(int leftId, int rightId)
        {
            return Entity.Delete(j => j.LeftId == leftId 
					&& j.RightId == rightId);
        }
        /// <summary>
        /// Gets a query by an index.
        /// </summary>
        public IQueryable<Tester.Data.Junction> GetByLeftId(int leftId)
        {
            if (Context.LoadOptions == null) 
                return Query.GetByLeftId.Invoke(Context, leftId);
            else
                return Entity.Where(j => j.LeftId == leftId);
        }
        /// <summary>
        /// Gets a query by an index.
        /// </summary>
        public IQueryable<Tester.Data.Junction> GetByRightId(int rightId)
        {
            if (Context.LoadOptions == null) 
                return Query.GetByRightId.Invoke(Context, rightId);
            else
                return Entity.Where(j => j.RightId == rightId);
        }

        #region Extensibility Method Definitions
        /// <summary>Called by the static constructor to add shared rules.</summary>
        static partial void AddRules();
        /// <summary>Called when the class is created.</summary>
        partial void OnCreated();
        #endregion
        
        #region Query
        /// <summary>
        /// A private class for lazy loading static compiled queries.
        /// </summary>
        private static partial class Query
        {

            internal static readonly Func<Tester.Data.TesterDataContext, int, int, Tester.Data.Junction> GetByKey = 
                System.Data.Linq.CompiledQuery.Compile(
                    (Tester.Data.TesterDataContext db, int leftId, int rightId) => 
                        db.Junction.FirstOrDefault(j => j.LeftId == leftId 
							&& j.RightId == rightId));

            internal static readonly Func<Tester.Data.TesterDataContext, int, IQueryable<Tester.Data.Junction>> GetByLeftId = 
                System.Data.Linq.CompiledQuery.Compile(
                    (Tester.Data.TesterDataContext db, int leftId) => 
                        db.Junction.Where(j => j.LeftId == leftId));

            internal static readonly Func<Tester.Data.TesterDataContext, int, IQueryable<Tester.Data.Junction>> GetByRightId = 
                System.Data.Linq.CompiledQuery.Compile(
                    (Tester.Data.TesterDataContext db, int rightId) => 
                        db.Junction.Where(j => j.RightId == rightId));

        }
        #endregion
    }
}
