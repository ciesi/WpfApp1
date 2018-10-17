using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace WpfApp1
{
    public interface ICalcFactor
    {
        decimal Value { get; }

        string ValuePresentation { get; }
    }

    public class SimpleCalcFactor : ICalcFactor
    {
        public SimpleCalcFactor(decimal value)
        {
            Value = value;
        }

        public decimal Value { get; }

        public string ValuePresentation => Value.ToString();
    }

    public class InnerCalcFactor : ICalcFactor, IList<Tuple<ICalcFactor, RechenZeichen>>
    {
        private IList<Tuple<ICalcFactor, RechenZeichen>> _zahlen = new List<Tuple<ICalcFactor, RechenZeichen>>();

        public Tuple<ICalcFactor, RechenZeichen> this[int index] { get => _zahlen[index]; set => _zahlen[index] = value; }

        public decimal Value
        {
            get
            {
                decimal val = 0m;
                RechenZeichen? zeichen = null;
                foreach (Tuple<ICalcFactor, RechenZeichen> item in _zahlen)
                {
                    if (zeichen.HasValue)
                    {
                        switch (zeichen.Value)
                        {
                            case RechenZeichen.Plus:
                                val += item.Item1.Value;
                                break;
                            case RechenZeichen.Minus:
                                val -= item.Item1.Value;
                                break;
                            case RechenZeichen.Mal:
                                val *= item.Item1.Value;
                                break;
                            case RechenZeichen.Geteilt:
                                val /= item.Item1.Value;
                                break;

                        }
                    }
                    else
                        val = item.Item1.Value;
                    zeichen = item.Item2;

                }

                return val;
            }
        }

        public int Count => _zahlen.Count;

        public bool IsReadOnly => _zahlen.IsReadOnly;

        public string ValuePresentation
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("(");
                foreach (Tuple<ICalcFactor, RechenZeichen> item in _zahlen)
                {
                    sb.AppendFormat(CultureInfo.CurrentCulture, "{0} ", item.Item1.ValuePresentation);
                    switch (item.Item2)
                    {
                        case RechenZeichen.Plus:
                            sb.Append(" + ");
                            break;
                        case RechenZeichen.Minus:
                            sb.Append(" - ");
                            break;
                        case RechenZeichen.Mal:
                            sb.Append(" * ");
                            break;
                        case RechenZeichen.Geteilt:
                            sb.Append(" / ");
                            break;
                        case RechenZeichen.Gleich:
                            sb.Append(" =");
                            break;
                        default:
                            break;
                    }
                }
                sb.Append(")");
                return sb.ToString();
            }
        }

        public void Add(Tuple<ICalcFactor, RechenZeichen> item)
        {
            _zahlen.Add(item);
        }

        public void Clear()
        {
            _zahlen.Clear();
        }

        public bool Contains(Tuple<ICalcFactor, RechenZeichen> item)
        {
            return _zahlen.Contains(item);
        }

        public void CopyTo(Tuple<ICalcFactor, RechenZeichen>[] array, int arrayIndex)
        {
            _zahlen.CopyTo(array, arrayIndex);
        }

        public IEnumerator<Tuple<ICalcFactor, RechenZeichen>> GetEnumerator()
        {
            return _zahlen.GetEnumerator();
        }

        public int IndexOf(Tuple<ICalcFactor, RechenZeichen> item)
        {
            return _zahlen.IndexOf(item);
        }

        public void Insert(int index, Tuple<ICalcFactor, RechenZeichen> item)
        {
            _zahlen.Insert(index,item);
        }

        public bool Remove(Tuple<ICalcFactor, RechenZeichen> item)
        {
            return _zahlen.Remove(item);
        }

        public void RemoveAt(int index)
        {
            _zahlen.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _zahlen.GetEnumerator();
        }
    }
}