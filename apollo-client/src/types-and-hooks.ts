import { gql } from '@apollo/client';
import * as Apollo from '@apollo/client';
export type Maybe<T> = T | null;
export type InputMaybe<T> = Maybe<T>;
export type Exact<T extends { [key: string]: unknown }> = { [K in keyof T]: T[K] };
export type MakeOptional<T, K extends keyof T> = Omit<T, K> & { [SubKey in K]?: Maybe<T[SubKey]> };
export type MakeMaybe<T, K extends keyof T> = Omit<T, K> & { [SubKey in K]: Maybe<T[SubKey]> };
const defaultOptions = {} as const;
/** All built-in and custom scalars, mapped to their actual values */
export type Scalars = {
  ID: string;
  String: string;
  Boolean: boolean;
  Int: number;
  Float: number;
  /** The `DateTime` scalar represents an ISO-8601 compliant date time type. */
  DateTime: any;
  UUID: any;
};

/** A connection to a list of items. */
export type AllBooksConnection = {
  __typename?: 'AllBooksConnection';
  /** A list of edges. */
  edges?: Maybe<Array<AllBooksEdge>>;
  /** A flattened list of the nodes. */
  nodes?: Maybe<Array<Book>>;
  /** Information to aid in pagination. */
  pageInfo: PageInfo;
};

/** An edge in a connection. */
export type AllBooksEdge = {
  __typename?: 'AllBooksEdge';
  /** A cursor for use in pagination. */
  cursor: Scalars['String'];
  /** The item at the end of the edge. */
  node: Book;
};

export type Author = {
  __typename?: 'Author';
  birthDate?: Maybe<Scalars['DateTime']>;
  deathDate?: Maybe<Scalars['DateTime']>;
  name: Scalars['String'];
};

export type AuthorFilterInput = {
  and?: InputMaybe<Array<AuthorFilterInput>>;
  birthDate?: InputMaybe<ComparableNullableOfDateTimeOperationFilterInput>;
  deathDate?: InputMaybe<ComparableNullableOfDateTimeOperationFilterInput>;
  name?: InputMaybe<StringOperationFilterInput>;
  or?: InputMaybe<Array<AuthorFilterInput>>;
};

export type Book = {
  __typename?: 'Book';
  authors: Array<Author>;
  id: Scalars['UUID'];
  isbn: Scalars['String'];
  name: Scalars['String'];
  publishedOn: Scalars['DateTime'];
  publisher: PublishingHouse;
};

export type BookFilterInput = {
  and?: InputMaybe<Array<BookFilterInput>>;
  authors?: InputMaybe<ListFilterInputTypeOfAuthorFilterInput>;
  id?: InputMaybe<ComparableGuidOperationFilterInput>;
  isbn?: InputMaybe<StringOperationFilterInput>;
  name?: InputMaybe<StringOperationFilterInput>;
  or?: InputMaybe<Array<BookFilterInput>>;
  publishedOn?: InputMaybe<ComparableDateTimeOperationFilterInput>;
  publisher?: InputMaybe<PublishingHouseFilterInput>;
};

export type BookSortInput = {
  id?: InputMaybe<SortEnumType>;
  isbn?: InputMaybe<SortEnumType>;
  name?: InputMaybe<SortEnumType>;
  publishedOn?: InputMaybe<SortEnumType>;
  publisher?: InputMaybe<PublishingHouseSortInput>;
};

export type CheckedOutBook = {
  __typename?: 'CheckedOutBook';
  bookId: Scalars['UUID'];
  checkedOutOn: Scalars['DateTime'];
  returnBy: Scalars['DateTime'];
};

export type ComparableDateTimeOperationFilterInput = {
  eq?: InputMaybe<Scalars['DateTime']>;
  gt?: InputMaybe<Scalars['DateTime']>;
  gte?: InputMaybe<Scalars['DateTime']>;
  in?: InputMaybe<Array<Scalars['DateTime']>>;
  lt?: InputMaybe<Scalars['DateTime']>;
  lte?: InputMaybe<Scalars['DateTime']>;
  neq?: InputMaybe<Scalars['DateTime']>;
  ngt?: InputMaybe<Scalars['DateTime']>;
  ngte?: InputMaybe<Scalars['DateTime']>;
  nin?: InputMaybe<Array<Scalars['DateTime']>>;
  nlt?: InputMaybe<Scalars['DateTime']>;
  nlte?: InputMaybe<Scalars['DateTime']>;
};

export type ComparableGuidOperationFilterInput = {
  eq?: InputMaybe<Scalars['UUID']>;
  gt?: InputMaybe<Scalars['UUID']>;
  gte?: InputMaybe<Scalars['UUID']>;
  in?: InputMaybe<Array<Scalars['UUID']>>;
  lt?: InputMaybe<Scalars['UUID']>;
  lte?: InputMaybe<Scalars['UUID']>;
  neq?: InputMaybe<Scalars['UUID']>;
  ngt?: InputMaybe<Scalars['UUID']>;
  ngte?: InputMaybe<Scalars['UUID']>;
  nin?: InputMaybe<Array<Scalars['UUID']>>;
  nlt?: InputMaybe<Scalars['UUID']>;
  nlte?: InputMaybe<Scalars['UUID']>;
};

export type ComparableNullableOfDateTimeOperationFilterInput = {
  eq?: InputMaybe<Scalars['DateTime']>;
  gt?: InputMaybe<Scalars['DateTime']>;
  gte?: InputMaybe<Scalars['DateTime']>;
  in?: InputMaybe<Array<InputMaybe<Scalars['DateTime']>>>;
  lt?: InputMaybe<Scalars['DateTime']>;
  lte?: InputMaybe<Scalars['DateTime']>;
  neq?: InputMaybe<Scalars['DateTime']>;
  ngt?: InputMaybe<Scalars['DateTime']>;
  ngte?: InputMaybe<Scalars['DateTime']>;
  nin?: InputMaybe<Array<InputMaybe<Scalars['DateTime']>>>;
  nlt?: InputMaybe<Scalars['DateTime']>;
  nlte?: InputMaybe<Scalars['DateTime']>;
};

export type ListFilterInputTypeOfAuthorFilterInput = {
  all?: InputMaybe<AuthorFilterInput>;
  any?: InputMaybe<Scalars['Boolean']>;
  none?: InputMaybe<AuthorFilterInput>;
  some?: InputMaybe<AuthorFilterInput>;
};

export type Mutation = {
  __typename?: 'Mutation';
  checkoutBook?: Maybe<User>;
  createUser?: Maybe<User>;
  returnBook?: Maybe<User>;
};


export type MutationCheckoutBookArgs = {
  bookId: Scalars['UUID'];
  userId: Scalars['UUID'];
};


export type MutationCreateUserArgs = {
  name: Scalars['String'];
};


export type MutationReturnBookArgs = {
  bookId: Scalars['UUID'];
  userId: Scalars['UUID'];
};

/** Information about pagination in a connection. */
export type PageInfo = {
  __typename?: 'PageInfo';
  /** When paginating forwards, the cursor to continue. */
  endCursor?: Maybe<Scalars['String']>;
  /** Indicates whether more edges exist following the set defined by the clients arguments. */
  hasNextPage: Scalars['Boolean'];
  /** Indicates whether more edges exist prior the set defined by the clients arguments. */
  hasPreviousPage: Scalars['Boolean'];
  /** When paginating backwards, the cursor to continue. */
  startCursor?: Maybe<Scalars['String']>;
};

export type PublishingHouse = {
  __typename?: 'PublishingHouse';
  name: Scalars['String'];
};

export type PublishingHouseFilterInput = {
  and?: InputMaybe<Array<PublishingHouseFilterInput>>;
  name?: InputMaybe<StringOperationFilterInput>;
  or?: InputMaybe<Array<PublishingHouseFilterInput>>;
};

export type PublishingHouseSortInput = {
  name?: InputMaybe<SortEnumType>;
};

export type Query = {
  __typename?: 'Query';
  allBooks?: Maybe<AllBooksConnection>;
  book?: Maybe<Book>;
  user?: Maybe<User>;
};


export type QueryAllBooksArgs = {
  after?: InputMaybe<Scalars['String']>;
  before?: InputMaybe<Scalars['String']>;
  first?: InputMaybe<Scalars['Int']>;
  last?: InputMaybe<Scalars['Int']>;
  order?: InputMaybe<Array<BookSortInput>>;
  where?: InputMaybe<BookFilterInput>;
};


export type QueryBookArgs = {
  id: Scalars['UUID'];
};


export type QueryUserArgs = {
  id: Scalars['UUID'];
};

export enum SortEnumType {
  Asc = 'ASC',
  Desc = 'DESC'
}

export type StringOperationFilterInput = {
  and?: InputMaybe<Array<StringOperationFilterInput>>;
  contains?: InputMaybe<Scalars['String']>;
  endsWith?: InputMaybe<Scalars['String']>;
  eq?: InputMaybe<Scalars['String']>;
  in?: InputMaybe<Array<InputMaybe<Scalars['String']>>>;
  ncontains?: InputMaybe<Scalars['String']>;
  nendsWith?: InputMaybe<Scalars['String']>;
  neq?: InputMaybe<Scalars['String']>;
  nin?: InputMaybe<Array<InputMaybe<Scalars['String']>>>;
  nstartsWith?: InputMaybe<Scalars['String']>;
  or?: InputMaybe<Array<StringOperationFilterInput>>;
  startsWith?: InputMaybe<Scalars['String']>;
};

export type User = {
  __typename?: 'User';
  books: Array<CheckedOutBook>;
  id: Scalars['UUID'];
  isInGoodStanding: Scalars['Boolean'];
  name: Scalars['String'];
};

export type AppQueryVariables = Exact<{ [key: string]: never; }>;


export type AppQuery = { __typename?: 'Query', allBooks?: { __typename?: 'AllBooksConnection', nodes?: Array<{ __typename?: 'Book', id: any, isbn: string, name: string }> | null } | null };

export type BooksPageFragment = { __typename?: 'AllBooksConnection', nodes?: Array<{ __typename?: 'Book', id: any, isbn: string, name: string }> | null };

export type CreateUserMutationVariables = Exact<{
  username: Scalars['String'];
}>;


export type CreateUserMutation = { __typename?: 'Mutation', createUser?: { __typename?: 'User', id: any, name: string } | null };

export const BooksPageFragmentDoc = gql`
    fragment BooksPage on AllBooksConnection {
  nodes {
    id
    isbn
    name
  }
}
    `;
export const AppDocument = gql`
    query App {
  allBooks {
    ...BooksPage
  }
}
    ${BooksPageFragmentDoc}`;

/**
 * __useAppQuery__
 *
 * To run a query within a React component, call `useAppQuery` and pass it any options that fit your needs.
 * When your component renders, `useAppQuery` returns an object from Apollo Client that contains loading, error, and data properties
 * you can use to render your UI.
 *
 * @param baseOptions options that will be passed into the query, supported options are listed on: https://www.apollographql.com/docs/react/api/react-hooks/#options;
 *
 * @example
 * const { data, loading, error } = useAppQuery({
 *   variables: {
 *   },
 * });
 */
export function useAppQuery(baseOptions?: Apollo.QueryHookOptions<AppQuery, AppQueryVariables>) {
        const options = {...defaultOptions, ...baseOptions}
        return Apollo.useQuery<AppQuery, AppQueryVariables>(AppDocument, options);
      }
export function useAppLazyQuery(baseOptions?: Apollo.LazyQueryHookOptions<AppQuery, AppQueryVariables>) {
          const options = {...defaultOptions, ...baseOptions}
          return Apollo.useLazyQuery<AppQuery, AppQueryVariables>(AppDocument, options);
        }
export type AppQueryHookResult = ReturnType<typeof useAppQuery>;
export type AppLazyQueryHookResult = ReturnType<typeof useAppLazyQuery>;
export type AppQueryResult = Apollo.QueryResult<AppQuery, AppQueryVariables>;
export const CreateUserDocument = gql`
    mutation CreateUser($username: String!) {
  createUser(name: $username) {
    id
    name
  }
}
    `;
export type CreateUserMutationFn = Apollo.MutationFunction<CreateUserMutation, CreateUserMutationVariables>;

/**
 * __useCreateUserMutation__
 *
 * To run a mutation, you first call `useCreateUserMutation` within a React component and pass it any options that fit your needs.
 * When your component renders, `useCreateUserMutation` returns a tuple that includes:
 * - A mutate function that you can call at any time to execute the mutation
 * - An object with fields that represent the current status of the mutation's execution
 *
 * @param baseOptions options that will be passed into the mutation, supported options are listed on: https://www.apollographql.com/docs/react/api/react-hooks/#options-2;
 *
 * @example
 * const [createUserMutation, { data, loading, error }] = useCreateUserMutation({
 *   variables: {
 *      username: // value for 'username'
 *   },
 * });
 */
export function useCreateUserMutation(baseOptions?: Apollo.MutationHookOptions<CreateUserMutation, CreateUserMutationVariables>) {
        const options = {...defaultOptions, ...baseOptions}
        return Apollo.useMutation<CreateUserMutation, CreateUserMutationVariables>(CreateUserDocument, options);
      }
export type CreateUserMutationHookResult = ReturnType<typeof useCreateUserMutation>;
export type CreateUserMutationResult = Apollo.MutationResult<CreateUserMutation>;
export type CreateUserMutationOptions = Apollo.BaseMutationOptions<CreateUserMutation, CreateUserMutationVariables>;