//N51 - HT1

//- buyurtmalar(Order) va bitta order ichidagi sotib olingan tovarlar ( Product ) uchun endpoint qanday bo'lishligi kerak ?
//- web api konfiguratsiyasi uchun yaratilgan fayllar qaysi layerda turishligi kerak ?
//- controller ichida nechta service inject qilish mumkin ?
//- controller ichida foundations service larini ishlatish mumkinmi ?


/*  buyurtmalar(Order) va bitta order ichidagi sotib olingan tovarlar ( Product ) uchun endpoint qanday bo'lishligi kerak ?
 *  
 *  Javoblar:
 *  Get methodida parameter sifatida Order ning id si fromroute orqali kirib keladi
 *    
 *  Create bu methoda esa user id si va productlar listi(yoki productlar id ning listi) parameter sifatida kirib keladi. va yarilgan orderni qataradi
 *  
 *  Update bu methodda esa orderni o'zi kirib keladi. Method esa update bo'lgan order qataradi
 *  
 *  Delete bu methodda parameter sifatida order kirib keladi, va bu method delete bo'lgan order qaytardi 
 */

/*  web api konfiguratsiyasi uchun yaratilgan fayllar qaysi layerda turishligi kerak ?
 * 
 * Javoblar:
 * konfiguratsiya uchun yaratilgan fayllar Api dagi Properties folderining lauchSetting.json 
 */