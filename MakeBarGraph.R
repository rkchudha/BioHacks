nums <- read.table("CancerCount.csv",sep = ",", header = TRUE)


mat <- matrix(c(nums$Unfavourable, nums$Favourable), ncol=2) 

barplot(t(mat), horiz = TRUE, xlab = "Number Of Related Genes", col = c( "cornflowerblue","cadetblue3"), legend = c("Unfavourable", "Favourable"))