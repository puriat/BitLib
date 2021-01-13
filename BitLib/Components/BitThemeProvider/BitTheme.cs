using System;
using System.Text;

namespace BitLib
{
    public class BitTheme
    {
        internal string Id { get; private set; } = IdGeneratorHelper.Generate("matBlazor_theme_");


        /// <summary>
        /// The theme text color
        /// </summary>
        public string Color { get; set; }

        public string GetClass()
        {
            return Id;
        }


        public event EventHandler<EventArgs> Changed;


        public void ThemeHasChanged()
        {
            OnChanged();
        }


        protected virtual void GenerateStyle(StringBuilder sb)
        {
        }

        public string GetStyle()
        {
            var sb = new StringBuilder();
            GenerateStyle(sb);
            return sb.ToString();
        }


        public string GetStyleTag()
        {
            var sb = new StringBuilder();
            sb.AppendLine("<style>");
            sb.Append(".");
            sb.AppendLine(Id);
            sb.AppendLine("{");
            GenerateStyle(sb);
            sb.AppendLine("}");
            sb.AppendLine("</style>");
            return sb.ToString();
        }

        protected virtual void OnChanged()
        {
            Changed?.Invoke(this, EventArgs.Empty);
        }
    }
}