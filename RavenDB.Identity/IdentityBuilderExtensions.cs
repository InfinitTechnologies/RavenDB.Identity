using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raven.Identity
{
	/// <summary>
	/// Extends <see cref="IdentityBuilder" /> to add RavenDB.Identity stores.
	/// </summary>
    public static class IdentityBuilderExtensions
    {
		/// <summary>
		/// Adds the RavenDB UserStore.
		/// </summary>
		/// <typeparam name="TUser">The type of user. This should be a class you created derived from <see cref="IdentityUser"/>.</typeparam>
		/// <param name="builder"></param>
		/// <returns>The IdentityBuilder.</returns>
		public static IdentityBuilder AddRavenDbStores<TUser>(this IdentityBuilder builder)
			where TUser : IdentityUser
		{
			return builder.AddRavenDbStores<TUser, IdentityRole>();
		}

		/// <summary>
		/// Adds the RavenDB UserStore and RoleStore.
		/// </summary>
		/// <typeparam name="TUser">The type of user. This should be a class you created derived from <see cref="IdentityUser"/>.</typeparam>
		/// <typeparam name="TRole">The type of role. This should be a class you created derived from <see cref="IdentityRole"/>.</typeparam>
		/// <param name="builder"></param>
		/// <returns>The IdentityBuilder.</returns>
		public static IdentityBuilder AddRavenDbStores<TUser, TRole>(this IdentityBuilder builder)
			where TUser : IdentityUser
			where TRole : IdentityRole, new()
		{
			builder.Services.AddScoped<IUserStore<TUser>, UserStore<TUser, TRole>>();
			builder.Services.AddScoped<IRoleStore<TRole>, RoleStore<TRole>>();

			return builder;
		}
	}
}
