﻿using Reload.Common.Interfaces.Repositories;
using Reload.Common.Models;
using Reload.Repository.Contexts;

namespace Reload.Repository.Repositories
{
	/// <summary>The handload repository.</summary>
	public class HandloadRepository : BaseRepository<Handload>, IHandloadRepository
	{
		/// <summary>Initializes a new instance of the <see cref="HandloadRepository"/> class.</summary>
		/// <param name="context">The context.</param>
		public HandloadRepository() : base(new HandloadContext()) { }
	}
}