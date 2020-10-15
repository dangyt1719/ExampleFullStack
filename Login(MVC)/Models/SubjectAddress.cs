using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Login_MVC_.Models
{
    public class SubjectAddress
    {
        public long N_ADDRESS_ID { get; set; } // Идентификатор адреса
        public long N_ADDR_TYPE_ID { get; set; } // Идентификатор типа адреса
        public long N_PAR_ADDR_ID { get; set; } // Идентификатор вышестоящего адреса
        public string VC_NAME { get; set; } // Полный адрес
        public string VC_CODE { get; set; } // Краткий адрес
        public string VC_VISUAL_CODE { get; set; } // Отображаемый адрес
        public string VC_ADDRESS { get; set; } // Нестандартный адрес
        public string VC_FLAT { get; set; } // Комната, квартира
        public long N_REGION_ID { get; set; } // Идентификатор региона
        public long N_ENTRANCE_NO { get; set; } // Подъезд
        public long N_FLOOR_NO { get; set; } // Этаж
        public string VC_DIS_CODE { get; set; } // Код домофона
        public long N_FIRM_ID { get; set; } // Идентификатор создавшей фирмы
        public string VC_ADDR_REM { get; set; } // Комментарий адреса
        public long N_SUBJ_ADDRESS_ID { get; set; } // Идентификатор записи
        public long N_SUBJECT_ID { get; set; } // Идентификатор СУ
        public long N_SUBJ_ADDR_TYPE_ID { get; set; } // Идентификатор вида адреса
        public long N_ADDR_STATE_ID { get; set; } // Идентификатор состояния адреса
        public string VC_REM { get; set; } // Комментарий
        public long N_BIND_ADDR_ID { get; set; } // Идентификатор связанного адреса
        public string VC_ADDR_STATE_CODE { get; set; } // Код состояния адреса
        public string VC_ADDR_STATE_NAME { get; set; } // Наименование состояния адреса
        public string VC_SUBJ_ADDR_TYPE_NAME { get; set; } // Наименование вида адреса
        public string VC_SUBJ_ADDR_TYPE_CODE { get; set; } // Код вида адреса
        public string VC_ADDR_TYPE_NAME { get; set; } // Наименование типа адреса
        public string VC_ADDR_TYPE_CODE { get; set; } // Код типа адреса
        public string VC_PAR_ADDR_NAME { get; set; } // Наименование вышестоящего адреса
        public string VC_PAR_ADDR_CODE { get; set; } // Код вышестоящего адреса
        public string VC_SUBJ_NAME { get; set; } // Наименование СУ
        public string VC_SUBJ_CODE { get; set; } // Код СУ
        public long N_SUBJ_TYPE_ID { get; set; } // Идентификатор типа СУ
        public DateTime D_BEGIN { get; set; } // Дата начала действия
        public DateTime D_END { get; set; } // Дата окончания действия
        public string C_FL_MAIN { get; set; } // Флаг основного адреса
        /// <summary>
        /// Пустой конструктор класса
        /// </summary>
        //public SubjectAddress() { }
    }
}