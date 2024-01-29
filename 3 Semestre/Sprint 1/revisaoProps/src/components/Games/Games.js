import {StyleSheet, Text, View} from 'react-native'

const Games = ({ name, price }) => {
    return ( 
        <View style={styles.container}>
            <Text style={styles.text}>{name}</Text>
            <Text style={styles.text}>R${price}</Text>
        </View>
    )
}

const styles = StyleSheet.create({
    container: {
        borderColor: 'green',
        margin: 5,
        padding: 10,
        borderColor: 'blue',
        borderWidth: 1,
        borderRadius: 10,
    }
})

export default Games;