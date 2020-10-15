using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Login_MVC_.Models
{
    public class RecommendedPayRow

    {
        /// <summary>
        /// Идентификатор счета
        /// </summary>
        public long N_ACCOUNT_ID { get; set; }
        /// <summary>
        /// Идентификатор услуги
        /// </summary>
        public long N_GOOD_ID { get; set; }
        /// <summary>
        /// Комментарий
        /// </summary>
        public string VC_REM { get; set; }
        /// <summary>
        /// Дата начала периода
        /// </summary>
        public DateTime? D_BEGIN { get; set; }
        /// <summary>
        /// Дата конца периода
        /// </summary>
        public DateTime? D_END { get; set; }
        /// <summary>
        /// Сумма
        /// </summary>
        public decimal N_SUM { get; set; }
        /// <summary>
        /// Номер линии
        /// </summary>
        public long N_LINE_NO { get; set; }
        /// <summary>
        /// Флаг итоговой строки, 'Y' - итоговая строка, 'N' - неитоговая строка
        /// </summary>
        public string C_FL_TOTALS { get; set; }
        public long N_TYPE { get; set; }
        public long N_SECTION_ID { get; set; }
        public RecommendedPayRow() { }
    }
}