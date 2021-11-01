/*
	This file is part of Editor Extensions Redux /L Unleashed
		© 2018-2021 LisiasT : http://lisias.net <support@lisias.net>
		© 2016-2018 LinuxGyruGamer
		© 2013-2016 MachXXV

	Editor Extensions Redux /L is double licensed, as follows:
		* SKL 1.0 : https://ksp.lisias.net/SKL-1_0.txt
		* GPL 2.0 : https://www.gnu.org/licenses/gpl-2.0.txt

	And you are allowed to choose the License that better suit your needs.

	Editor Extensions Redux /L Unleashed is distributed in the hope that
	it will be useful, but WITHOUT ANY WARRANTY; without even the implied
	warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.

	You should have received a copy of the SKL Standard License 1.0
	along with Editor Extensions Redux /L Unleashed.
	If not, see <https://ksp.lisias.net/SKL-1_0.txt>.

	You should have received a copy of the GNU General Public License 2.0
	along with Editor Extensions Redux /L Unleashed.
	If not, see <https://www.gnu.org/licenses/>.

*/
using System;

namespace EditorExtensionsRedux.StripSymmetry
{
    internal abstract class Enums<U> where U : class
    {
        /// <summary>
        /// Converts the string representation of the name or numeric value of one or more enumerated constants to an equivalent enumerated object.
        /// </summary>
        /// <typeparam name="TEnumType">The type of the enumeration.</typeparam>
        /// <param name="value">A string containing the name or value to convert.</param>
        /// <exception cref="System.ArgumentNullException">value is null</exception>
        /// <exception cref="System.ArgumentException">value is either an empty string or only contains white space.-or- value is a name, but not one of the named constants defined for the enumeration.</exception>
        /// <exception cref="System.OverflowException">value is outside the range of the underlying type of EnumType</exception>
        /// <returns>An object of type enumType whose value is represented by value.</returns>
        static public TEnumType Parse<TEnumType>(string value) where TEnumType : U
        {
            return (TEnumType)Enum.Parse(typeof(TEnumType), value);
        }
    }

    abstract class Enums : Enums<Enum>
    {
    }
}
