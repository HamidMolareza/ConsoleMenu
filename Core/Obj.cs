using System;

namespace Core
{
    public class Obj
    {
        private int? _leftMargin;
        private int? _rightMargin;

        public int? LeftMargin
        {
            get => _leftMargin;
            set
            {
                if (value is not null && value < 0)
                    throw new ArgumentOutOfRangeException(nameof(LeftMargin));
                _leftMargin = value;
            }
        }

        public int? RightMargin
        {
            get => _rightMargin;
            set
            {
                if (value is not null && value < 0)
                    throw new ArgumentOutOfRangeException(nameof(RightMargin));
                _rightMargin = value;
            }
        }
    }
}