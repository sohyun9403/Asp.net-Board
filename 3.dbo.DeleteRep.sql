USE [sohyundb]
GO

/****** Object:  StoredProcedure [dbo].[DeleteRep]    Script Date: 2020-03-19 오후 4:24:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--ALTER Proc [dbo].[DeleteBasic]

--       @Num Int
--As
   
--     Delete board Where Num = @Num;



--*** 답글이 있으면 삭제불가/답글이 없을때만 삭제가능 

CREATE Proc [dbo].[DeleteRep]

   @seq Int

AS
   Declare @RCount int 

   Select @RCount = count(*) from boards where @seq=idk

   
   if @Rcount =0                                 

   delete from boards where seq=@seq               
GO

