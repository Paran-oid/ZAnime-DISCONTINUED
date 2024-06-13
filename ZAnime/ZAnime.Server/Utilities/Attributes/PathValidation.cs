using System.ComponentModel.DataAnnotations;
using Zanime.Server.Models.Core;
using Zanime.Server.Models.Main;
using Zanime.Server.Models.Main.DTO.Actor_Model;
using Zanime.Server.Models.Main.DTO.Anime_Model;
using Zanime.Server.Models.Main.DTO.Character_Model;

namespace Zanime.Server.Utilities.Attributes
{
    public class PathValidation<T> : ValidationAttribute where T : class
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("File can't be empty");
            }

            string path = (string)value;

            if (validationContext.ObjectInstance is T)
            {
                if (File.Exists(path))
                {
                    Console.WriteLine($"we found the file inside {path} (User machine)");

                    object instance = validationContext.ObjectInstance;
                    string directory;

                    switch (instance)
                    {
                        case ActorVM actorVM:
                            directory = $"C:\\Users\\azizh\\source\\repos\\Team Development\\ZAnime\\Shared\\wwwroot\\Data\\Actors\\{actorVM.Name}";
                            break;

                        case AnimeVM animeVM:
                            directory = $"C:\\Users\\azizh\\source\\repos\\Team Development\\ZAnime\\Shared\\wwwroot\\Data\\Animes\\{animeVM.Title}";
                            break;

                        case CharacterVM characterVM:
                            directory = $"C:\\Users\\azizh\\source\\repos\\Team Development\\ZAnime\\Shared\\wwwroot\\Data\\Characters\\{characterVM.Name}";
                            break;

                        default:
                            return new ValidationResult("Object was not recognized");
                    }
                    if (!Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }
                    string destinationPath = Path.Combine(directory, Path.GetFileName(path));
                    if (!File.Exists(destinationPath))
                        File.Copy(path, destinationPath);

                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("File not found");
                }
            }
            return new ValidationResult("Object used is not recognized");
            //We then check if the file already exists or not inside pictures, user{ID} FOLDER
            //If it exists we pick it
            //Else we add the picture there
            //ELse if the folder doesn't exist we create it anyway
        }
    }
}