using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApiArt.Models;

namespace WebApiArt.Data
{
    public static class ArtInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            ArtContext context = applicationBuilder.ApplicationServices.CreateScope()
                .ServiceProvider.GetRequiredService<ArtContext>();
            try
            {
                //Delete the database if you need to apply a new Migration
                //context.Database.EnsureDeleted();
                //Create the database if it does not exist and apply the Migration
                context.Database.Migrate();

                // Adding Seed Data.
                if (!context.ArtTypes.Any())
                {
                    context.ArtTypes.AddRange(
                     new ArtType
                     {
                         Type = "Painting"
                     },
                     new ArtType
                     {
                         Type = "Drawing"
                     },
                     new ArtType
                     {
                         Type = "Sculpture"
                     },
                     new ArtType
                     {
                         Type = "Plastic Art"
                     },
                     new ArtType
                     {
                         Type = "Decorative Art"
                     },
                     new ArtType
                     {
                         Type = "Visual Art"
                     }
                   );
                    context.SaveChanges();
                }
                if (!context.Artworks.Any())
                {
                    context.Artworks.AddRange(
                     new Artwork
                     {
                         Name = "Red Dot",
                         Value = 12000d,
                         Completed = DateTime.Parse("2002-06-06"),
                         Description = "Painting of a large Red Dot on a white backgraound.",
                         ArtTypeID = (context.ArtTypes.Where(d => d.Type == "Painting").SingleOrDefault().ID)
                     },
                     new Artwork
                     {
                         Name = "Rossini Regal",
                         Value = 99000d,
                         Completed = DateTime.Parse("2009-12-06"),
                         Description = "Photograph of a regal horse.",
                         ArtTypeID = (context.ArtTypes.Where(d => d.Type == "Visual Art").SingleOrDefault().ID)
                     },
                     new Artwork
                     {
                         Name = "Love Sublime",
                         Value = 19.99d,
                         Completed = DateTime.Parse("2015-09-21"),
                         Description = "Soapstone Sculpture of woman's face gazing at an unknown figure.",
                         ArtTypeID = (context.ArtTypes.Where(d => d.Type == "Sculpture").SingleOrDefault().ID)
                     },
                     new Artwork
                     {
                         Name = "Igor Smashes",
                         Value = 750000.50d,
                         Completed = DateTime.Parse("1976-07-11"),
                         Description = "Abstract concept of smashed emotion done in crumpled paper.",
                         ArtTypeID = (context.ArtTypes.Where(d => d.Type == "Plastic Art").SingleOrDefault().ID)
                     });
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.GetBaseException().Message);
            }
        }
    }
}
