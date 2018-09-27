﻿//
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

using System;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using KeyVault.TestFramework;
using Microsoft.Azure.KeyVault.Cryptography.Algorithms;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Microsoft.Azure.KeyVault.Jose.Tests
{

    /// <summary>
    /// Verify Symmetric Key.
    /// </summary>
    public class KeyVaultJweTests : IClassFixture<KeyVaultTestFixture>
    {
        // NOTE: This is actually a certificate chain, the leaf certificate has a private key and permits
        //       digital signature and key encipherment
        private const string  _certificateContent = "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";
        //private const string  _certificateContent = "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";

        private KeyVaultTestFixture _fixture;

        private static RandomNumberGenerator _rng = RandomNumberGenerator.Create();

        public KeyVaultJweTests( KeyVaultTestFixture testFixture )
        {
            _fixture = testFixture;
        }

        private byte[] CertificateContent
        {
            get { return Convert.FromBase64String( _certificateContent ); }
        }

        private string CertificatePassword
        {
            get { return "123"; }
        }

        private KeyVaultClient GetKeyVaultClient()
        {
            if ( HttpMockServer.Mode == HttpRecorderMode.Record )
            {
                HttpMockServer.Variables["VaultAddress"] = _fixture.vaultAddress;
                HttpMockServer.Variables["KeyName"]      = _fixture.keyName;
                HttpMockServer.Variables["KeyVersion"]   = _fixture.keyVersion;
            }
            else
            {
                _fixture.vaultAddress = HttpMockServer.Variables["VaultAddress"];
                _fixture.keyName      = HttpMockServer.Variables["KeyName"];
                _fixture.keyVersion   = HttpMockServer.Variables["KeyVersion"];
            }

            _fixture.keyIdentifier = new KeyIdentifier( _fixture.vaultAddress, _fixture.keyName, _fixture.keyVersion );

            return _fixture.CreateKeyVaultClient();
        }

        /// <summary>
        /// Test resolving a key from a key in a vault using various KeyVaultKeyResolver constructors.
        /// </summary>
        [Fact]
        public void KeyVault_Jose_KeyResolverRoundTrip()
        {
            using ( MockContext context = MockContext.Start( this.GetType().FullName ) )
            {

                // Arrange
                var client = GetKeyVaultClient();
                var vault  = _fixture.vaultAddress;

                var collection = new X509Certificate2Collection();

                collection.Import( CertificateContent, CertificatePassword, X509KeyStorageFlags.Exportable );

                var certificate      = collection.Cast<X509Certificate2>().First( ( c ) => { return c.HasPrivateKey; } );
                var certificateBytes = certificate.Export( X509ContentType.Pkcs12 );

                var secret = client.SetSecretAsync( vault, "Certificate", Convert.ToBase64String( certificateBytes ), null, "application/pkcs12" ).GetAwaiter().GetResult();

                if ( secret != null )
                {
                    try
                    {
                        // ctor with client
                        var expressResolver = new ExpressCertificateResolver( client );
                        var simpleResolver  = new SimpleKeyResolver();

                        simpleResolver.Add( new CertificateKey( certificate ) );

                        var baseKey    = expressResolver.ResolveKeyAsync( secret.SecretIdentifier.BaseIdentifier, default( CancellationToken ) ).GetAwaiter().GetResult();
                        var versionKey = expressResolver.ResolveKeyAsync( secret.SecretIdentifier.Identifier, default( CancellationToken ) ).GetAwaiter().GetResult();

                        Assert.Equal( baseKey.Kid, versionKey.Kid );

                        // Create some plaintext
                        var plaintext = new byte[256];
                        _rng.GetBytes( plaintext );

                        // Protect the plain text with a wrapped symmetric key.
                        var    jwe       = JsonWebEncryption.ProtectCompactAsync( baseKey, baseKey.DefaultKeyWrapAlgorithm, Aes128CbcHmacSha256.AlgorithmName, plaintext ).GetAwaiter().GetResult();
                        byte[] decrypted = JsonWebEncryption.UnprotectCompactAsync( simpleResolver, jwe ).GetAwaiter().GetResult();

                        Assert.Equal( plaintext, decrypted );
                    }
                    finally
                    {
                        // Delete the key
                        client.DeleteSecretAsync( vault, "Certificate" ).GetAwaiter().GetResult();
                    }
                }
            }
        }
    }
}
