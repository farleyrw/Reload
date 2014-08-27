﻿using System.Data.Entity;

namespace Reload.Repository
{
	/// <summary>The base db context.</summary>
	public class BaseContext : DbContext
	{
		// TODO: this needs a db connection factory to connect to the different contexts that are created.
		/// <summary>Initializes a new instance of the <see cref="BaseContext"/> class.</summary>
		public BaseContext() // : base("DefaultConnection")
		{
			this.Configuration.LazyLoadingEnabled = false;
		}
	}
}