import { gql } from '@apollo/client'
import { useCreateUserMutation } from './types-and-hooks'

gql`
  mutation CreateUser($username: String!) {
    createUser(name: $username) {
      id
      name
    }
  }
`

function CreateUser() {
  const [command] = useCreateUserMutation()

  const createUser = () =>
    command({
      variables: {
        username: 'asdf',
      },
    })

  return (
    <div className="CreateUser">
      <button style={{ float: 'right' }} onClick={createUser}>
        Create User
      </button>
    </div>
  )
}

export default CreateUser
