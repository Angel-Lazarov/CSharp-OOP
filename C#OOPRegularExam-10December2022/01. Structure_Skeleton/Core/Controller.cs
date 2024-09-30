using ChristmasPastryShop.Core.Contracts;
using ChristmasPastryShop.Models.Booths;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Utilities.Messages;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChristmasPastryShop.Core
{
    internal class Controller : IController
    {
        private BoothRepository booths;

        public Controller()
        {
            booths = new BoothRepository();
        }

        public string AddBooth(int capacity)
        {
            Booth booth = new Booth(booths.Models.Count + 1, capacity);
            booths.AddModel(booth);
            return string.Format(OutputMessages.NewBoothAdded, booth.BoothId, booth.Capacity);
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            ICocktail cocktail = null;

            if (cocktailTypeName == "Hibernation")
            {
                cocktail = new Hibernation(cocktailName, size);
            }
            else if (cocktailTypeName == "MulledWine")
            {
                cocktail = new MulledWine(cocktailName, size);
            }
            else
            {
                return string.Format(OutputMessages.InvalidCocktailType, cocktailTypeName);
            }

            if (size != "Small" && size != "Middle" && size != "Large")
            {
                return string.Format(OutputMessages.InvalidCocktailSize, size);
            }

            IBooth currentBooth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            if (currentBooth.CocktailMenu.Models.Any(c => c.Name == cocktailName) && currentBooth.CocktailMenu.Models.Any(c => c.Size == size))
            {
                return string.Format(OutputMessages.CocktailAlreadyAdded, size, cocktailName);
            }

            currentBooth.CocktailMenu.AddModel(cocktail);

            return string.Format(OutputMessages.NewCocktailAdded, size, cocktailName, cocktailTypeName);
        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            //if (delicacyTypeName != "Gingerbread" && delicacyTypeName != "Stolen")
            //{
            //    return string.Format(OutputMessages.InvalidDelicacyType, delicacyTypeName);
            //}

            IDelicacy delicacy = null;

            if (delicacyTypeName == "Gingerbread")
            {
                delicacy = new Gingerbread(delicacyName);
            }
            else if (delicacyTypeName == "Stolen")
            {
                delicacy = new Stolen(delicacyName);
            }
            else
            {
                return string.Format(OutputMessages.InvalidDelicacyType, delicacyTypeName);
            }

            IBooth currentBooth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            if (currentBooth.DelicacyMenu.Models.Any(m => m.Name == delicacyName))
            {
                return string.Format(OutputMessages.DelicacyAlreadyAdded, delicacyName);
            }


            currentBooth.DelicacyMenu.AddModel(delicacy);

            return string.Format(OutputMessages.NewDelicacyAdded, delicacyTypeName, delicacyName);
        }

        public string BoothReport(int boothId)
        {
            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            return booth.ToString();
        }

        public string LeaveBooth(int boothId)
        {
            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Bill {booth.CurrentBill:f2} lv");
            stringBuilder.AppendLine($"Booth {boothId} is now available!");

            booth.Charge();
            booth.ChangeStatus();

            return stringBuilder.ToString().Trim();
        }

        public string ReserveBooth(int countOfPeople)
        {
            List<IBooth> orderedBooths = booths.Models.Where(b => b.Capacity >= countOfPeople).Where(b => b.IsReserved == false).OrderBy(b => b.Capacity).ThenByDescending(b => b.BoothId).ToList();
            //IBooth currentBooth = orderedBooths[0]; -->>>>>> AutOfRangeException!!!!
            IBooth currentBooth = orderedBooths.FirstOrDefault();

            /*
            AddBooth 5
            AddDelicacy 1 Gingerbread Santabiscuit
            AddCocktail 1 MulledWine Redstar Middle
            ReserveBooth 6

             */

            //IBooth currentBooth = booths.Models.Where(b => !b.IsReserved && b.Capacity >= countOfPeople).OrderBy(b => b.Capacity).ThenByDescending(b => b.BoothId).FirstOrDefault();

            if (currentBooth == null)
            {
                return string.Format(OutputMessages.NoAvailableBooth, countOfPeople);
            }

            currentBooth.ChangeStatus();

            return string.Format(OutputMessages.BoothReservedSuccessfully, currentBooth.BoothId, countOfPeople);
        }

        public string TryOrder(int boothId, string order)
        {
            string[] orderInfo = order.Split('/');
            string itemTypeName = orderInfo[0];
            string itemName = orderInfo[1];
            int countOrderedPieces = int.Parse(orderInfo[2]);

            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);
            IDelicacy delicacy = null;
            ICocktail cocktail = null;

            if (itemTypeName == "Gingerbread")
            {
                delicacy = booth.DelicacyMenu.Models.FirstOrDefault(d => d.Name == itemName);

                if (delicacy == null)
                {
                    return string.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);
                }
            }
            else if (itemTypeName == "Stolen")
            {
                delicacy = booth.DelicacyMenu.Models.FirstOrDefault(d => d.Name == itemName);

                if (delicacy == null)
                {
                    return string.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);
                }
            }
            else if (itemTypeName == "Hibernation")
            {
                cocktail = booth.CocktailMenu.Models.FirstOrDefault(d => d.Name == itemName);

                if (cocktail == null)
                {
                    return string.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);
                }
            }
            else if (itemTypeName == "MulledWine")
            {
                cocktail = booth.CocktailMenu.Models.FirstOrDefault(d => d.Name == itemName);

                if (cocktail == null)
                {
                    return string.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);
                }
            }
            else
            {
                return string.Format(OutputMessages.NotRecognizedType, itemTypeName);
            }

            if (delicacy == null) //ordered item is cockatail
            {
                string size = orderInfo[3];
                if (cocktail.Size != size)
                {
                    return string.Format(OutputMessages.CocktailStillNotAdded, size, itemName);
                }

                booth.UpdateCurrentBill(cocktail.Price * countOrderedPieces);
                return string.Format(OutputMessages.SuccessfullyOrdered, booth.BoothId, countOrderedPieces, itemName);
            }
            else if (cocktail == null) // ordered item is delicacy
            {
                booth.UpdateCurrentBill(delicacy.Price * countOrderedPieces);
                return string.Format(OutputMessages.SuccessfullyOrdered, booth.BoothId, countOrderedPieces, itemName);
            }
            else
            {
                return string.Format(OutputMessages.NotRecognizedType, itemTypeName);
            }

        }
    }
}