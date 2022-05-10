#import "IOSToUnity.h"
  
  @implementation IOSToUnity
  
  /**
   @param str
   @return str
  */
extern "C" const char * getString(const char *str)
{
    NSLog(@"From iOS to Unity : %s", str);
    return strdup(str);
}
  
  /**
   @param date
   @return No
  */
extern "C" void setDate(const char *date)
{
    /**
     @param obj
     @param method
     @param msg
     UnitySendMessage (const char* obj, const char* method, const char* msg ) ;
    */
    UnitySendMessage("PublicGameObject", "GetDate", date);
}
  
  /**
   @param date
   @return date
   */
  extern "C" int setMyInt(int date)
  {
    return date;
  }
   
   @end
