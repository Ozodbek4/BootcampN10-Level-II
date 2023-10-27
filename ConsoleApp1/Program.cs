/*
 * N57 HomeTask
 * 
 * Savollar:
 *  - external configuration ga kirishi mumkin bo'lgan qiymatlarga misollar keltiring
    - configuration modelga yozishimiz mumkin bo'lgan ma'lumot tiplarini yozing
 * 
 * Javoblar:
 *  1. - external configuration ga kirishi mumkin bo'lgan qiymatlarga misollar keltiring
 * Configuration provider(appSetting.Json, appSettingDevelopment.Json, appSettingProvider.Json), Environment variable, User secret, Command Line Argument 
 * 
 * 
 *  2. - configuration modelga yozishimiz mumkin bo'lgan ma'lumot tiplarini yozing
 * Hamma configuration modellarni AddSingleto<T>, AddScopped<T>, AddTrensient. <T> - bu register qilinadigan servicelar hisoblanadi
 * 
 */