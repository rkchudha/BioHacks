# Creates a bar graph indicating the number of genes related to to a specific cancer and whether it's favourable


nums <- read.table("CancerCount.csv",sep = ",", header = TRUE)


mat <- matrix(c(nums$Unfavourable, nums$Favourable), ncol=2) 

barplot(t(mat), horiz = TRUE, names.arg = nums$BodyPart, las=2, main = "Cancer And Related Genes", xlab = "Number Of Related Genes", col = c( "cornflowerblue","cadetblue3"), legend = c("Unfavourable", "Favourable"))