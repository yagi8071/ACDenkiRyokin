using ACDenkiRyokin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using System.Text;
using System.Web;

namespace ACDenkiRyokin.Models
{
    public class CsvService
    {
            // ヘッダーとボディ（定義情報）を結合してCSVデータ文字列を作成
            public static string CreateCsv(List<denki_ryokin> TableList)
            {
                var sb = new StringBuilder();

                // ヘッダーの作成
                sb.AppendLine(CreateCsvHeader(headerArray));

                // ボディの作成
                TableList.ForEach(a => sb.AppendLine(CreateCsvBody(a)));

                return sb.ToString();
            }

            // CSVヘッダーの配列
            private static string[] headerArray = { "ManagementID", "ChangeInfomation", "Date" , "Applicant" , "Status" };

            // CSVヘッダー文字列を作成
            private static string CreateCsvHeader(string[] headerArray)
            {
                var sb = new StringBuilder();
                foreach (var header in headerArray)
                {
                    sb.Append($@"""{header}"",");
                }
                // 最後のカンマを削除して返す
                return sb.Remove(sb.Length - 1, 1).ToString();
            }

            // CSV定義情報文字列の作成
            private static string CreateCsvBody(denki_ryokin a)
            {
                var sb = new StringBuilder();
                sb.Append(string.Format($@"""{a.ManagementID}"","));
                sb.Append(string.Format($@"""{a.ChangeInfomation}"","));
                sb.Append(string.Format($@"""{a.Date}"","));
                sb.Append(string.Format($@"""{a.Applicant}"","));
                sb.Append(string.Format($@"""{a.Status}"","));
            return sb.ToString();
            }
    }
}