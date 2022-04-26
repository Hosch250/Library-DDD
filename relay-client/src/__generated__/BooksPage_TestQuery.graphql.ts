/**
 * @generated SignedSource<<fe0d951afe365dc9b2b542987a997ca2>>
 * @lightSyntaxTransform
 * @nogrep
 */

/* tslint:disable */
/* eslint-disable */
// @ts-nocheck

import { ConcreteRequest, Query } from 'relay-runtime';
import { FragmentRefs } from "relay-runtime";
export type BooksPage_TestQuery$variables = {};
export type BooksPage_TestQuery$data = {
  readonly allBooks: {
    readonly " $fragmentSpreads": FragmentRefs<"BooksPage_query">;
  } | null;
};
export type BooksPage_TestQuery = {
  variables: BooksPage_TestQuery$variables;
  response: BooksPage_TestQuery$data;
};

const node: ConcreteRequest = (function(){
var v0 = {
  "enumValues": null,
  "nullable": false,
  "plural": false,
  "type": "String"
};
return {
  "fragment": {
    "argumentDefinitions": [],
    "kind": "Fragment",
    "metadata": null,
    "name": "BooksPage_TestQuery",
    "selections": [
      {
        "alias": null,
        "args": null,
        "concreteType": "AllBooksConnection",
        "kind": "LinkedField",
        "name": "allBooks",
        "plural": false,
        "selections": [
          {
            "args": null,
            "kind": "FragmentSpread",
            "name": "BooksPage_query"
          }
        ],
        "storageKey": null
      }
    ],
    "type": "Query",
    "abstractKey": null
  },
  "kind": "Request",
  "operation": {
    "argumentDefinitions": [],
    "kind": "Operation",
    "name": "BooksPage_TestQuery",
    "selections": [
      {
        "alias": null,
        "args": null,
        "concreteType": "AllBooksConnection",
        "kind": "LinkedField",
        "name": "allBooks",
        "plural": false,
        "selections": [
          {
            "alias": null,
            "args": null,
            "concreteType": "Book",
            "kind": "LinkedField",
            "name": "nodes",
            "plural": true,
            "selections": [
              {
                "alias": null,
                "args": null,
                "kind": "ScalarField",
                "name": "id",
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "kind": "ScalarField",
                "name": "isbn",
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "kind": "ScalarField",
                "name": "name",
                "storageKey": null
              }
            ],
            "storageKey": null
          }
        ],
        "storageKey": null
      }
    ]
  },
  "params": {
    "cacheID": "7accf4e7abace23a557501ce7255e159",
    "id": null,
    "metadata": {
      "relayTestingSelectionTypeInfo": {
        "allBooks": {
          "enumValues": null,
          "nullable": true,
          "plural": false,
          "type": "AllBooksConnection"
        },
        "allBooks.nodes": {
          "enumValues": null,
          "nullable": true,
          "plural": true,
          "type": "Book"
        },
        "allBooks.nodes.id": {
          "enumValues": null,
          "nullable": false,
          "plural": false,
          "type": "UUID"
        },
        "allBooks.nodes.isbn": (v0/*: any*/),
        "allBooks.nodes.name": (v0/*: any*/)
      }
    },
    "name": "BooksPage_TestQuery",
    "operationKind": "query",
    "text": "query BooksPage_TestQuery {\n  allBooks {\n    ...BooksPage_query\n  }\n}\n\nfragment BooksPage_query on AllBooksConnection {\n  nodes {\n    id\n    isbn\n    name\n  }\n}\n"
  }
};
})();

(node as any).hash = "a712ed612c6ae197c5deea27030dbc70";

export default node;
