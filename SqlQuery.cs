using System;
using System.Text;
using System.Collections.Generic;

namespace SCLibrary.Sql
{
    public class SqlQuery
    {
        private StringBuilder m_builder;
        public SqlQuery(){
            m_builder = new StringBuilder();
        }
        public SqlQuery INSERT(string value, params KeyValuePair<string,string>[] option ) {
            int i = 0;
            StringBuilder sbHeader = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();
            foreach (var s in option)
            {
                sbHeader.Append(s.Key + ",");
                sbValue.Append("'"+ s.Value + "',");
            }
            m_builder.Append("INSERT INTO " + value + " (" + sbHeader.ToString().TrimEnd(',') + ") " + "VALUES(" + sbValue.ToString().TrimEnd(',') + ")");
            return this;
        }
        public SqlQuery SELECT(params string[] option)
        {
            string s = "";
            if (option.Length > 0)
                s = string.Join(",", option);
            else
                s = "*";
            m_builder.Append("SELECT " + s + " ");
            return this;
        }
        public SqlQuery FROM(string value) {
            m_builder.Append("FROM " + value + " ");
            return this;
        }
        public SqlQuery WHERE(params string[] option)
        {
            int i = 0;
            StringBuilder sb = new StringBuilder();
            string sRes = "";
            bool first = true;
            foreach (string s in option)
            {
                if (i == 0)
                {
                    if (first)
                        sRes = s + "=";
                    else
                        sRes = " " + s + "=";
                    first = false;
                    i++;
                }
                else if (i == 1)
                {
                    sRes += "'" + s + "'";
                    sb.Append(sRes + ",");
                    i = 0;
                }
            }
            m_builder.Append("WHERE " + sb.ToString().TrimEnd(',') + " ");
            return this;
        }
        public SqlQuery UPDATE(string value)
        {
            m_builder.Append("UPDATE " + value + " ");
            return this;
        }
        public SqlQuery DELETE(string value, params string[] option)
        {
            return this;
        }
        public SqlQuery SET(params string[] option)
        {
            int i = 0;
            StringBuilder sb = new StringBuilder();
            string sRes = "";
            bool first = true;
            foreach (string s in option)
            {
                if (i == 0)
                {
                    if (first)
                        sRes = s + "=";
                    else
                        sRes = " " + s + "=";
                    first = false;
                    i++;
                }
                else if (i == 1)
                {
                    sRes += "'" + s + "'";
                    sb.Append(sRes + ",");
                    i = 0;
                }
            }
            m_builder.Append("SET " + sb.ToString().TrimEnd(',') + " ");
            return this;
        }
        public override string ToString()
        {
            return m_builder.ToString();
        }
    }
}
