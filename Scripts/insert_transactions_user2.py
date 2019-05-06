import csv

userId = '2909D0F3-27E5-48B5-A79B-3C47DF26B394'

output = open("insert_transactions_user2.txt", "w")
with open('user1data.csv') as csv_file:
    csv_reader = csv.reader(csv_file, delimiter=',')
    line_count = 0
    current_account = ''
    for row in csv_reader:
        if line_count > 0:
            accountType = row[0]
            accountNumber = row[1]
            processingDate = row[2].replace('-','') + ' 12:00:00 AM'
            balance = row[3]
            transactionType = 0
            if row[4] == 'CR':
                transactionType = 0
            else:
                transactionType = 1
            amount = row[5].replace('$','')
            description = row[6]

            accountId = ''
            if accountType == 'Checking':
                accountId = '43720334-5D0A-426C-9BB4-CD97B3A13201'
            else:
                accountId = 'CDCD00DB-9BB0-42C8-9412-5E058C6EE89F'

            if len(balance) > 0:
                output.write(f'DECLARE @accountId UNIQUEIDENTIFIER = \'{accountId}\';\n\
DECLARE @transactionType INT = 0;\n\
DECLARE @amount DECIMAL(19,4) = {balance};\n\
DECLARE @description VARCHAR(MAX) = \'Account opening\';\n\
DECLARE @processingDate DateTime = \'{processingDate}\';\n\
INSERT INTO [dbo].[Transaction]\n\
VALUES (NEWID(), @accountId, @transactionType, @amount, @description, @processingDate);\n')
            else:
                output.write(f'DECLARE @accountId UNIQUEIDENTIFIER = \'{accountId}\';\n\
DECLARE @transactionType INT = {transactionType};\n\
DECLARE @amount DECIMAL(19,4) = {amount};\n\
DECLARE @description VARCHAR(MAX) = \'{description}\';\n\
DECLARE @processingDate DateTime = \'{processingDate}\';\n\
INSERT INTO [dbo].[Transaction]\n\
VALUES (NEWID(), @accountId, @transactionType, @amount, @description, @processingDate);\n')
            output.write('\nGO\n\n')
        line_count += 1
output.close()

