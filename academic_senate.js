import * as path from "path";
import * as fs from "fs";

const BATCH_SIZE = 100;

let connection = "localhost";
let database = "AcademicSenate";
let targetPath = "F:\\web project academic senate";

if (!fs.existsSync(targetPath))
    require("mkdirp").sync(targetPath);

let exportCollections = [
    {
        collection: "Users", query: {}, projection: {}, sort: {}, skip: 0, limit: 0, filename: "web project academic senate", exportType: "bson", fields: [
            "_id",
            "Designation",
            "Name",
            "Pass",
            "Proposals",
            "UserName"
        ]
    }
];
let totalDocs = 0;
let collectionResult = {};//collectionResult:{[name:string]:number}

function exportCollection(collectionParams) {
    let {collection, filename, query, projection, sort, skip, limit, fields, exportType} = collectionParams;

    let continueRead = true;
    let filepath = path.resolve(targetPath, filename || (collection + ".json"));

    console.log(`export docs from ${connection}:${database}:${collection} to ${filepath} start...`);

    if (fs.existsSync(filepath))
        fs.unlinkSync(filepath);

    if (!_.isEmpty(fields)) {
        projection = {};
        fields.forEach(field => {
            projection[field] = 1;
        })
    } else {
        fields = mb.tryGetFields({ connection, db: database, collection });
    }

    collectionResult[collection] = 0;

    let theSkip = skip;
    let theLimit = limit || Number.MAX_SAFE_INTEGER;
    while (continueRead) {
        let docs = mb.readFromDb({ connection, db: database, collection, query, projection, sort, skip: theSkip, limit: theLimit > BATCH_SIZE ? BATCH_SIZE : theLimit });
        let readLength = docs.length;

        theSkip += readLength;
        theLimit -= readLength;

        if (readLength < BATCH_SIZE)
            continueRead = false;

        if (readLength) {
            collectionResult[collection] += readLength;
            let jsonContent = mb.docsToJSON({ docs, fields, jsonType: exportType });
            fs.appendFileSync(filepath, jsonContent);

            console.log(`export ${collectionResult[collection]} docs to ${path.basename(filepath)}.`);
            totalDocs += docs.length;
        }

        sleep(10)
    }

    console.log(`export ${collectionResult[collection]} docs from ${connection}:${database}:${collection} to ${filepath} finished.`);
}

exportCollections.forEach(it => exportCollection(it));
_.delay(() => mb.openFolder(targetPath), 1000);

if (exportCollections.length > 1)
    console.log(`Total ${totalDocs} document(s) of ${exportCollections.length} collections successfully exported.`, collectionResult);
