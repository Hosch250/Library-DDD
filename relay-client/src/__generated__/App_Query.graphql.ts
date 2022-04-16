/**
 * @generated SignedSource<<9ddd8f8e6c74e36bfb2ffcc3c9dc71d4>>
 * @lightSyntaxTransform
 * @nogrep
 */

/* tslint:disable */
/* eslint-disable */
// @ts-nocheck

import { ConcreteRequest, Query } from 'relay-runtime';
import { FragmentRefs } from "relay-runtime";
export type App_Query$variables = {};
export type App_Query$data = {
  readonly allBooks: {
    readonly " $fragmentSpreads": FragmentRefs<"BooksPage_query">;
  } | null;
};
export type App_Query = {
  variables: App_Query$variables;
  response: App_Query$data;
};

const node: ConcreteRequest = {
  "fragment": {
    "argumentDefinitions": [],
    "kind": "Fragment",
    "metadata": null,
    "name": "App_Query",
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
    "name": "App_Query",
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
    "cacheID": "7c2f716577ff8780f6d9bbc52e791ecb",
    "id": null,
    "metadata": {},
    "name": "App_Query",
    "operationKind": "query",
    "text": "query App_Query {\n  allBooks {\n    ...BooksPage_query\n  }\n}\n\nfragment BooksPage_query on AllBooksConnection {\n  nodes {\n    id\n    isbn\n    name\n  }\n}\n"
  }
};

(node as any).hash = "f7fb5e8c6beec377e7a529be24641904";

export default node;
