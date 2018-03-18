tabl <- read.table("FunctionCount.csv",sep = ",", header = TRUE)


barplot(tabl$FunctionCount, names.arg = tabl$Gene, las=2, main = "Versatile Genes!",horiz = TRUE, xlab = "Number Of Functions", col = c("cadetblue3"))