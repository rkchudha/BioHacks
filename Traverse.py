if __name__ == '__main__':

    file_read = open("Chr20GeneData.tsv", "r")
    file_write = open("CancerCount.csv", "w")

    i = 0
    # dictionary string to list: [unfavourable_count, favourable_count]
    cancers_all = {}
    for line in file_read:
        i += 1
        if i != 1:
            columns = line.split("\t")
            prog = columns[17]
            if prog != "NA":
                prog_split = prog.split(", ")
                for j in range(len(prog_split)):
                    cancer = (prog_split[j].split())[0].split(":")[0]
                    fav = (prog_split[j].split())[-1]
                    if cancer not in cancers_all:
                        cancers_all[cancer] = [0, 0]
                    if fav == "(favourable)":
                        cancers_all[cancer][1] += 1
                    else:
                        cancers_all[cancer][0] += 1
    file_write.write("BodyPart,Unfavourable,Favourable\n")
    for cancer in cancers_all:
        file_write.write(cancer + "," + str(cancers_all[cancer][0]) + "," + str(cancers_all[cancer][1]) + "\n")
