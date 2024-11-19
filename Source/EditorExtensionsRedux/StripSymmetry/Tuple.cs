﻿/*
	This file is part of Editor Extensions Redux /L Unleashed
		© 2018-2024 LisiasT : https://lisias.net <support@lisias.net>
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
using System.Collections;
using System.Collections.Generic;

namespace EditorExtensionsRedux.StripSymmetry
{
    static class Tuple
    {
        public static Tuple<T1, T2> Create<T1, T2>(T1 a, T2 b)
        {
            return new Tuple<T1, T2>(a, b);
        }

        internal static int CombineHashCodes(int h1, int h2)
        {
            return (h1 << 5) + h1 ^ h2;
        }
    }

    public struct Tuple<T1, T2> : IComparable
    {
        public T1 Item1
        {
            get;
            set;
        }

        public T2 Item2
        {
            get;
            set;
        }

        public Tuple(T1 a, T2 b)
            : this()
        {
            Item1 = a;
            Item2 = b;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj, Comparer<object>.Default);
        }

        public bool Equals(object obj, IEqualityComparer cmp)
        {
            if (!(obj is Tuple<T1, T2>))
            {
                return false;
            }
            var other = (Tuple<T1, T2>)obj;
            return cmp.Equals(Item1, other.Item1) && cmp.Equals(Item2, other.Item2);
        }

        public override int GetHashCode()
        {
            return GetHashCode(EqualityComparer<object>.Default);
        }

        public int GetHashCode(IEqualityComparer cmp)
        {
            return Tuple.CombineHashCodes(cmp.GetHashCode(Item1), cmp.GetHashCode(Item2));
        }

        public int CompareTo(object obj)
        {
            return CompareTo(obj, Comparer<object>.Default);
        }

        public int CompareTo(object obj, IComparer cmp)
        {
            if (obj == null)
            {
                return 1;
            }
            var other = (Tuple<T1, T2>)obj;
            var result = cmp.Compare(Item1, other.Item1);
            if (result != 0)
            {
                return result;
            }
            result = cmp.Compare(Item2, other.Item2);
            return result;
        }
    }
}
