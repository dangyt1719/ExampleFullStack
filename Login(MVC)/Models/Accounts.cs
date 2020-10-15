using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Login_MVC_.Models
{
    public class Accounts
    {
        /// <summary>
        /// Идентификатор абонента
        /// </summary>
        public long N_SUBJECT_ID { get; set; }
        /// <summary>
        /// Краткое наименование абонента
        /// </summary>
        public string VC_SUBJ_CODE { get; set; }
        /// <summary>
        /// Полное наименование абонента
        /// </summary>
        public string VC_SUBJ_NAME { get; set; }
        /// <summary>
        /// Идентификатор счета
        /// </summary>
        public long N_ACCOUNT_ID { get; set; }
        /// <summary>
        /// Идентификатор валюты
        /// </summary>
        public long N_CURRENCY_ID { get; set; }
        /// <summary>
        /// Валюта
        /// </summary>
        public string VC_CURRENCY { get; set; }
        /// <summary>
        /// Международный код валюты
        /// </summary>
        public string VC_CURRENCY_CODE { get; set; }
        /// <summary>
        /// Краткое наименование счета
        /// </summary>
        public string VC_CODE { get; set; }
        /// <summary>
        /// Полное наименование счета
        /// </summary>
        public string VC_NAME { get; set; }
        /// <summary>
        /// Номер счета
        /// </summary>
        public string VC_ACCOUNT { get; set; }
        /// <summary>
        /// Дата открытия
        /// </summary>
        public DateTime? D_OPEN { get; set; }
        /// <summary>
        /// Дата закрытия
        /// </summary>
        public DateTime? D_CLOSE { get; set; }
        /// <summary>
        /// Суммарный кредитный лимит
        /// </summary>
        public decimal N_OVERDRAFT { get; set; }
        /// <summary>
        /// Ближайшая дата окончания
        /// </summary>
        public DateTime? D_OVERDRAFT_END { get; set; }
        /// <summary>
        /// Сумма постоянного кредитного лимита
        /// </summary>
        public decimal N_PERMANENT_OVERDRAFT { get; set; }
        /// <summary>
        /// Сумма временного кредитного лимита
        /// </summary>
        public decimal N_TEMPORAL_OVERDRAFT { get; set; }
        /// <summary>
        /// Дата временного кредитного лимита
        /// </summary>
        public DateTime? D_TEMP_OVERDRAFT_END { get; set; }
        /// <summary>
        /// Сумма для отложенной оплаты запланированных услуг
        /// </summary>
        public decimal N_SCHED_SERV_OVERDRAFT { get; set; }
        /// <summary>
        /// Дата отложенной оплаты запланированных услуг
        /// </summary>
        public DateTime? D_SCHED_SERV_OVERDRAFT_END { get; set; }
        /// <summary>
        /// Сумма для отложенной оплаты незапланированных услуг
        /// </summary>
        public decimal N_UNSCHED_SERV_OVERDRAFT { get; set; }
        /// <summary>
        /// Дата отложенной оплаты незапланированных услуг
        /// </summary>
        public DateTime? D_UNSCHED_SERV_OVERDRAFT_END { get; set; }
        /// <summary>
        /// Максимальный кредитный лимит
        /// </summary>
        public decimal N_MAX_OVERDRAFT { get; set; }
        /// <summary>
        /// Комментарий
        /// </summary>
        public string VC_REM { get; set; }
        /// <summary>
        /// Текущий баланс
        /// </summary>
        public decimal N_SUM_BAL { get; set; }
        /// <summary>
        /// Зарезервировано всего
        /// </summary>
        public decimal N_SUM_RESERVED { get; set; }
        /// <summary>
        /// Текущее резервирование
        /// </summary>
        public decimal N_SUM_RESERVED_CUR { get; set; }
        /// <summary>
        /// Доступно для использования
        /// </summary>
        public decimal N_SUM_FREE { get; set; }
        /// <summary>
        /// Идентификатор фирмы
        /// </summary>
        public long N_FIRM_ID { get; set; }


        public decimal RecPay { get; set; }
        /// <summary>
        /// Пустой конструктор
        /// </summary>
        // public Account() { }

    }
}