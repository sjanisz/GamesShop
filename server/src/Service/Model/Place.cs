using System;
using System.Text.RegularExpressions;

namespace Service.Model
{
    public class Place
    {
        private string placeName;

        public string PlaceName
        {
            get { return placeName; }
            set
            {
                placeName = String.Empty;
                // Check length is between 2 and 50 characters
                if((value.Length < 2) || (value.Length > 50))
                {
                    throw new ArgumentException("Place name should be between 2 and 50 characters, passed name: " + value);
                }

                string[] placeParts = value.Split(' ');

                // Split every part of place name by space and check regex
                foreach (string item in placeParts)
                {
                    if(!Regex.IsMatch(item, @"^[" + Utils.GetPolishCharactersSetRegex() + "]*$"))
                    {
                        throw new ArgumentException("Place should have valid name (single spaces and following characters: "
                            + Utils.GetPolishCharactersSetRegex() + "), following place name part is invalid:\""
                            + item + "\" where full place name is equal to " + value);
                    }
                }

                for(int i = 0; i < placeParts.Length; i++)
                {
                    placeParts[i] = placeParts[i].ToLower();
                    placeParts[i] = Char.ToLower(placeParts[i][0]) + placeParts[i].Substring(1);

                    if (i > 0)
                        placeName += ' ';

                    placeName += placeParts[i];
                }
            }
        }

        public string ProvinceName { get; set; }
    }
}