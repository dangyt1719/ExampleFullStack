using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Login_MVC_.Models
{
    public class Account_Curr_User
    {
        /// <summary>
        /// Идентификатор СУ
        /// </summary>
        public long N_SUBJECT_ID { get; set; }
        /// <summary>
        /// Идентификатор типа СУ
        /// </summary>
        public long N_SUBJ_TYPE_ID { get; set; }
        /// <summary>
        /// Идентификатор базового СУ
        /// </summary>
        public long N_BASE_SUBJECT_ID { get; set; }
        /// <summary>
        /// Идентификатор вышестоящего СУ
        /// </summary>
        public long N_PARENT_SUBJ_ID { get; set; }
        /// <summary>
        /// Идентификатор статуса СУ
        /// </summary>
        public long N_SUBJ_STATE_ID { get; set; }
        /// <summary>
        /// Наименование статуса СУ
        /// </summary>
        public string VC_SUBJ_STATE_NAME { get; set; }
        /// <summary>
        /// Идентификатор владельца
        /// </summary>
        public long N_OWNER_ID { get; set; }
        /// <summary>
        /// Полное наименование СУ
        /// </summary>
        public string VC_SUBJ_NAME { get; set; }
        /// <summary>
        /// Краткое наименование СУ
        /// </summary>
        public string VC_SUBJ_CODE { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public string VC_NAME { get; set; }
        /// <summary>
        /// Код
        /// </summary>
        public string VC_CODE { get; set; }
        /// <summary>
        /// Краткое наименование СУ в верхнем регистре
        /// </summary>
        public string VC_SUBJ_CODE_UPPER { get; set; }
        /// <summary>
        /// Полное наименование СУ в верхнем регистре
        /// </summary>
        public string VC_SUBJ_NAME_UPPER { get; set; }
        /// <summary>
        /// Полное наименование создателя
        /// </summary>
        public string VC_CREATOR_NAME { get; set; }
        /// <summary>
        /// Краткое наименование создателя
        /// </summary>
        public string VC_CREATOR_CODE { get; set; }
        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime D_CREATED { get; set; }
        /// <summary>
        /// Идентификатор создателя
        /// </summary>
        public long N_CREATOR_ID { get; set; }
        /// <summary>
        /// Индентификатор дилера
        /// </summary>
        public long N_RESELLER_ID { get; set; }
        /// <summary>
        /// Массив тегов
        /// </summary>
        public string[] TAGS { get; set; }
        /// <summary>
        /// Список тегов
        /// </summary>
        public string VC_TAGS { get; set; }
        /// <summary>
        /// Примечание
        /// </summary>
        public string VC_REM { get; set; }
        /// <summary>
        /// Идентификатор создавшей фирмы
        /// </summary>
        public long N_FIRM_ID { get; set; }
        /// <summary>
        /// Наименование создавшей фирмы
        /// </summary>
        public string VC_FIRM { get; set; }
        /// <summary>
        /// Идентификатор региона
        /// </summary>
        public long N_REGION_ID { get; set; }
        /// <summary>
        /// Наименование региона
        /// </summary>
        public string VC_REGION { get; set; }
        /// <summary>
        /// Дата актуализации (выверки) данных по СУ
        /// </summary>
        public DateTime D_ACTUALIZE { get; set; }
        /// <summary>
        /// Дополнительный код
        /// </summary>
        public string VC_CODE_ADD { get; set; }
        /// <summary>
        /// Дата последнего изменения
        /// </summary>
        public DateTime D_LOG_LAST_MOD { get; set; }
        /// <summary>
        /// Идентификатор сессии
        /// </summary>
        public long N_LOG_SESSION_ID { get; set; }
        /// <summary>
        /// Список групп СУ
        /// </summary>
        public string VC_SUBJ_GROUPS { get; set; }
        /// <summary>
        /// Список лицевых счетов абонента
        /// </summary>
        public string VC_PERSONAL_NO_LIST { get; set; }
        /// <summary>
        /// Список номеров документов абонента
        /// </summary>
        public string VC_DOC_NO_LIST { get; set; }
        /// <summary>
        /// Наименование базового субъекта учета
        /// </summary>
        public string VC_BASE_SUBJECT_NAME { get; set; }
        /// <summary>
        /// Идентификатор базового субъекта учета
        /// </summary>
        public long N_BASE_SUBJ_TYPE_ID { get; set; }
        /// <summary>
        /// Идентификатор группы
        /// </summary>
        public long N_SUBJ_GROUP_ID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string VC_SUBJ_GROUP_NAME { get; set; }

        //public Customer() { }
    }
}