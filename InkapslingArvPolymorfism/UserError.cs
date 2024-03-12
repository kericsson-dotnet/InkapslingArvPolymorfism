public abstract class UserError
{
   public abstract string UEMessage();
}

public class NumericInputError : UserError
{
   public override string UEMessage()
   {
      return "You tried to use a numeric input in a text only field. This fired an error!";
   }
}

public class TextInputError : UserError
{
   public override string UEMessage()
   {
      return "You tried to use a text input in a numeric only field. This fired an error!";
   }
}

public class ProfanityInputError : UserError
{
   public override string UEMessage()
   {
      return "You tried to use a profanity in a text only field. This fired an error!";
   }
}

public class NoInputError : UserError
{
   public override string UEMessage()
   {
      return "Missing input in a text only field. This fired an error!";
   }
}

public class RedundantUserErrorMessageError : UserError
{
   public override string UEMessage()
   {
      return "You triggered an redundant user error message. This in itself fired an error!";
   }
}
