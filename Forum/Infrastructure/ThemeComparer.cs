using System;
using System.Collections.Generic;
using Forum.Models;

namespace Forum.Infrastructure {
    class ThemeComparer : IEqualityComparer<Message> {

        // Products are equal if their names and product numbers are equal.
        public bool Equals(Message x, Message y) {

            //Check whether the compared objects reference the same data.
            if (Object.ReferenceEquals(x, y)) return true;

            //Check whether any of the compared objects is null.
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;

            //Check whether the products' properties are equal.
            return x.theme == y.theme;
        }

        // If Equals() returns true for a pair of objects
        // then GetHashCode() must return the same value for these objects.

        public int GetHashCode(Message message) {
            //Check whether the object is null
            if (Object.ReferenceEquals(message, null)) return 0;

            //Get hash code for the Name field if it is not null.
            int hashProductName = message.theme == null ? 0 : message.theme.GetHashCode();

            //Calculate the hash code for the product.
            return hashProductName;
        }
    }
}
