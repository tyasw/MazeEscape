using System;

/** TwoTuple.cs
 * 
 * Stores two objects of the same type.
 */
namespace MazeEscape.src {
    public class TwoTuple<T> {
        public T X { get; set; }
        public T Y { get; set; }

        public TwoTuple(T x,T y) {
            X = x;
            Y = y;
        }
    }
}
