USE [sohyundb]
GO


/****** Object:  StoredProcedure [dbo].[Numbering]    Script Date: 2020-03-19 오후 4:24:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[Numbering]

AS


--Select * From 
--( 
--Select top 3 seq, subject, readcount, regdate,Board.id  from board 
--Where notice ='1'
--Order by notice, regdate desc) a 



--UNION ALL 

--Select * From 
--( 
--Select top 100 * from board 
--Order by regdate desc ) b

--select [seq], [name], [subject], [readcount], [regdate], [email], [id], [thread], [depth], [content] 
--from [Board] as b 
--inner join
-- Member as m on b.id = m.memberId order by [seq] desc

 --select [seq],  [subject], [readcount], [regdate], [email], id, thread, depth, name
 -- from [Board] as b 
 -- inner join 
 -- Member as m on b.id = m.memberId order by [seq] desc

  --select [seq],  [subject], [readcount], [regdate],id, thread, depth
  --from [Board1] order by [seq] desc

  SELECT Num = ROW_NUMBER() OVER(ORDER BY thread) , * FROM Boards ORDER BY Num DESC
GO

