using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Login_MVC_.Models
{
    public class CustomerServices
    {

        public long N_SUBJ_SERV_ID { get; set; } // Идентификатор строки
        public long N_SUBJ_SERV_TYPE_ID { get; set; } // Тип привязки
        public long N_SUBJECT_ID { get; set; } // Субъект учёта
        public long N_SERVICE_ID { get; set; } // Служба
        public long N_OBJECT_ID { get; set; } // Компонент службы или отдельный ОУ
        public long N_AUTH_TYPE_ID { get; set; } // Тип авторизации
        public long N_OBJ_ADDRESS_ID { get; set; } // Интерфейс для управления
        public long N_PORT_NO { get; set; } // Номер IP-порта для управления
        public string VC_LOGIN { get; set; } // Логин
        public string VC_PASS { get; set; } // Пароль
        public string VC_HASH_PASS { get; set; } // Хэш пароля
        public string VC_VALUE { get; set; } // Строковой параметер для привязки
        public long N_VALUE { get; set; } // Числовой параметер для привязки
        public string C_ACTIVE { get; set; } // Признак активности
        public DateTime? D_LOG_LAST_MOD { get; set; } // Дата последнего изменения
        public long N_LOG_SESSION_ID { get; set; } // Идентификатор сессии
        public long N_HASH_TYPE_ID { get; set; } // Тип хэша пароля
        public long N_LOCALE_ID { get; set; } // Локаль
        public string VC_LOGIN_REAL { get; set; } // Действующий логин
        public string VC_SALT { get; set; } // Соль для хэширования
        public long N_SCN { get; set; } // Версия
        public string VC_SERVICE { get; set; } // Наименование службы
        public string VC_USER_SERVICE_NAME { get; set; } // Пользовательское наименование службы
        public string VC_OBJECT { get; set; } // Код ОУ
        public long N_OBJ_GOOD_ID { get; set; } // Идентификатор типа ОУ
        public string VC_OBJ_GOOD { get; set; } // Наименование типа ОУ
        public string VC_AUTH_TYPE { get; set; } // Наименование типа авторизации
        public string C_FL_EMPTY_PASS { get; set; } // Флаг не установленного пароля
        public long N_SERVICE_GOOD_ID { get; set; } // Идентификатор типа службы
        public long N_SERV_AUTH_TYPE_ID { get; set; } // Вид аутентификации абонента
        public string C_FL_PLAINTEXT_PASS { get; set; } // Признак хранения пароля в открытом виде

        public CustomerServices() { }
    }
}