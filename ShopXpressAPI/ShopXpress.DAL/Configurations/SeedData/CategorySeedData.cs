using ShopXpress.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopXpress.DAL.Configurations.SeedData;

public class CategorySeedData
{
    public static List<Category> Categories()
    {
        return new List<Category>()
        {
            new Category() { Id = Guid.Parse("4678572e-5d7b-47c2-ab80-f8d6d8977017"), Name = "Electronics" },
            new Category() { Id = Guid.Parse("afb069bc-7ae9-4b5e-bf74-3350fe341894"), Name = "Clothing" },
            new Category() { Id = Guid.Parse("d06c834b-b93e-4eb9-9b70-253709130797"), Name = "Food" },
            new Category() { Id = Guid.Parse("61547a5e-a885-4bae-b0e3-a233d9cb4692"), Name = "Toys" },
            new Category() { Id = Guid.Parse("55468074-b867-4dc9-b3dc-f3b4b890c6ac"), Name = "Books" },
            new Category() { Id = Guid.Parse("ad2cb3c0-17e2-4837-a96c-2e2756929859"), Name = "Furniture" },
            new Category() { Id = Guid.Parse("5fe177cd-aa1e-44be-81ad-7ba2dcb48cd5"), Name = "Health" },
            new Category() { Id = Guid.Parse("cc2b18a7-22af-4ad5-abc8-712b2b3588b6"), Name = "Beauty" },
            new Category() { Id = Guid.Parse("4ab2f398-3e1d-4cd0-8c21-55766bac483a"), Name = "Sports" },
            new Category() { Id = Guid.Parse("a5c375d9-ed54-4752-a4f0-6f13a8a3d2bf"), Name = "Automotive" },
            new Category() { Id = Guid.Parse("f84014a7-59df-4707-aa2c-5db4c49f81d4"), Name = "Tools" },
            new Category() { Id = Guid.Parse("ae99f4ce-bfd2-47d0-af39-421dfa008b4a"), Name = "Jewelry" },
            new Category() { Id = Guid.Parse("71ca42f5-3c50-4be7-bde5-d1d68b2bed41"), Name = "Music" },
            new Category() { Id = Guid.Parse("d998f5f4-0f79-42b1-abd2-21014501f5b6"), Name = "Movies" },
            new Category() { Id = Guid.Parse("a1ee8039-f651-4850-8cb1-ac1377eb7405"), Name = "Games" },
            new Category() { Id = Guid.Parse("8fa0d957-3aa3-40e3-97c6-c18c2c2d84d7"), Name = "Garden" },
            new Category() { Id = Guid.Parse("03699920-2ced-490e-8c5f-699c2897770c"), Name = "Pet" },
            new Category() { Id = Guid.Parse("0339b7e5-2910-459b-9dd7-dd7f21cf3b67"), Name = "Baby" },
            new Category() { Id = Guid.Parse("66b6f25b-7db1-4c6e-87b4-17b6dd781018"), Name = "Industrial" },
            new Category() { Id = Guid.Parse("46c5ea6e-1143-4e0b-868e-12b88f2885f8"), Name = "Grocery" },
            new Category() { Id = Guid.Parse("3be63b9d-0c02-4077-8d6a-d9e9f0945e19"), Name = "Handmade" },
            new Category() { Id = Guid.Parse("3658572e-5d7b-47c2-ab80-f8d6d8977017"), Name = "Other" }
        };
    }

}
