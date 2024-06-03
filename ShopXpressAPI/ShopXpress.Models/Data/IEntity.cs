using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopXpress.Models.Data;

/// <summary>
/// Interface for all entities
/// </summary>
public interface IEntity
{
    Guid Id { get; set; }
}
