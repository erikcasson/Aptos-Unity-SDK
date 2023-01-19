using Chaos.NaCl;
using System;
using System.Text.RegularExpressions;

namespace Aptos.Accounts
{
    /// <summary>
    /// Represents an Aptos account address
    /// https://aptos.dev/concepts/accounts
    /// </summary>
    public class AccountAddress
    {
        private static readonly int Length = 32;
        private readonly byte[] Address;

        /// <summary>
        /// Sets the bytes of an account Address.
        /// </summary>
        /// <param name="address"></param>
        public AccountAddress(byte[] address)
        {
            if (address.Length != Length)
            {
                // TODO: Throw Error
            }
            this.Address = address;
        }

        /// <summary>
        /// Convert Address bytes into hexadecimal string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ToHexString();
        }

        /// <summary>
        /// Convert Address to hexadecimal string.
        /// </summary>
        /// <returns>Address as hexadecimal string</returns>
        public string ToHexString()
        {
            string addressHex = BitConverter.ToString(Address); // Turn into hexadecimal string
            addressHex = addressHex.Replace("-", "").ToLowerInvariant(); // Remove '-' characters from hexa hash
            return "0x" + addressHex;
        }

        /// <summary>
        /// Returns an AccountAddress object from a hexadecimal Address.
        /// </summary>
        /// <param name="address"></param> Hexadecimal representation of an Address.
        /// <returns></returns>
        public static AccountAddress FromHex(string address)
        {
            string addr = address;
            if (address[0..2].Equals("0x")) { addr = address[2..]; }

            if (addr.Length < AccountAddress.Length * 2)
            {
                string pad = new string('0', AccountAddress.Length * 2 - addr.Length);
                addr = pad + addr;
            }

            return new AccountAddress(HexadecimalStringToByteArray_BestEffort(addr));
        }

        /// <summary>
        /// Verifies string Address is a proper hex
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        public static bool HexEnsure(string hex)
        {
            return Regex.Match(hex, "^#[0-9a-fA-F]{6}$").Success;
        }

        /// <summary>
        /// Generate an AccountAddress object from a given public key, byte array. 
        /// </summary>
        /// <param name="publicKey"></param>
        /// <returns></returns>
        public static AccountAddress FromKey(byte[] publicKey)
        {
            var sha256 = new Org.BouncyCastle.Crypto.Digests.Sha3Digest(256); // SHA256 it
            var addressBytes = new byte[Ed25519.PublicKeySizeInBytes + 1]; // +1 to contain signature scheme byte
            Array.Copy(publicKey, 0, addressBytes, 0, Ed25519.PublicKeySizeInBytes); // copy 32 bytes only

            // TODO: Turn signature scheme byte into CONSTANT
            byte sigScheme = 0x00;
            addressBytes[publicKey.Length] = sigScheme; // Append signature scheme byte to the end

            sha256.BlockUpdate(addressBytes, 0, addressBytes.Length);
            byte[] result = new byte[Ed25519.PublicKeySizeInBytes]; // Result hash must be 32 bytes
            sha256.DoFinal(result, 0);

            return new AccountAddress(result);
        }

        public static byte[] HexadecimalStringToByteArray_BestEffort(string input)
        {
            var outputLength = input.Length / 2;
            var output = new byte[outputLength];
            var numeral = new char[2];
            for (int i = 0; i < outputLength; i++)
            {
                input.CopyTo(i * 2, numeral, 0, 2);
                output[i] = Convert.ToByte(new string(numeral), 16);
            }
            return output;
        }

        /// <summary>
        /// https://github.com/aptos-labs/bcs
        /// https://aptos.dev/guides/creating-a-signed-transaction/#bcs
        /// Binary Canonical Serialization (BCS) is a serialization format applied to the raw (unsigned) transaction. 
        /// See BCS for a description of the design goals of BCS.
        /// BCS is not a self-describing format.As such, in order to deserialize a message, 
        /// one must know the message type and layout ahead of time.
        /// </summary>
        public void Serialize()
        {
            // TODO: Implement Serialize
            throw new NotImplementedException();
        }

        public AccountAddress Deserialize()
        {
            // TODO: Implement Serialize
            throw new NotImplementedException();
        }
    }
}